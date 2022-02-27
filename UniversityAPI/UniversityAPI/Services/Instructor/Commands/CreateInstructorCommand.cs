using System;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Instructor;
using UniversityAPI.Services.Wrappers;

namespace UniversityAPI.Services.Instructor.Commands
{
    public class CreateInstructorCommand : CreateInstructorRequest, IRequestWrapper<Data.Models.Instructor> { }

    public class CreateInstructorCommandHandler : IHandlerWrapper<CreateInstructorCommand, Data.Models.Instructor>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public CreateInstructorCommandHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<Response<Data.Models.Instructor>> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            // Buisness logic
            try
            {
                if (string.IsNullOrEmpty(request.FirstName)) throw new ArgumentNullException(nameof(request.FirstName));
                if (string.IsNullOrEmpty(request.LastName)) new ArgumentNullException(nameof(request.LastName));
                if (request.Birthday == null) throw new ArgumentNullException(nameof(request.Birthday));

                await _context.AddAsync(new Data.Models.Instructor()
                {
                    FirstName = request.FirstName,
                    MidName = request.MidName != null ? request.MidName : null,
                    LastName = request.LastName,
                    Birthday = request.Birthday,
                    EnrollmentDate = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                });

                await _context.SaveChangesAsync();

                return await Task.FromResult(Response.Ok<Data.Models.Instructor>("Instructor created."));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Response.Fail<Data.Models.Instructor>(ex.Message));
            }
        }
    }
}
