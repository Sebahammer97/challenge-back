using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Course;
using UniversityAPI.Services.Wrappers;

namespace UniversityAPI.Services.Course.Commands
{
    public class CreateCourseCommand : CreateCourseRequest, IRequestWrapper<Data.Models.Course> { }

    public class CreateCourseCommandHandler : IHandlerWrapper<CreateCourseCommand, Data.Models.Course>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public CreateCourseCommandHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<Response<Data.Models.Course>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            // Buisness logic
            try
            {
                if (string.IsNullOrEmpty(request.Title)) throw new ArgumentNullException(nameof(request.Title));
                if (request.Hours <= 0) throw new ArgumentNullException(nameof(request.Hours));
                if (request.InstructorId <= 0) throw new ArgumentNullException(nameof(request.InstructorId));
                if (request.Credits <= 0) throw new ArgumentNullException(nameof(request.Credits));

                var instructor = _context.Instructors.FirstOrDefault(x => x.Id == request.InstructorId && x.SoftDeleted == null);

                if (instructor == null) throw new Exception("Instructor not found.");

                await _context.AddAsync(new Data.Models.Course()
                {
                    Title = request.Title,
                    Hours = request.Hours,
                    Credits = request.Credits,
                    Instructor = instructor,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                });

                await _context.SaveChangesAsync();

                return await Task.FromResult(Response.Ok<Data.Models.Course>("Course created."));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Response.Fail<Data.Models.Course>(ex.Message));
            }
        }
    }
}
