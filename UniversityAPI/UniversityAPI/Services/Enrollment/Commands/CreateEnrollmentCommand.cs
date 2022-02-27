using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Enrollment;
using UniversityAPI.Services.Wrappers;

namespace UniversityAPI.Services.Enrollment.Commands
{
    public class CreateEnrollmentCommand : CreateEnrollmentRequest, IRequestWrapper<Data.Models.Enrollment> { }

    public class CreateEnrollmentCommandHandler : IHandlerWrapper<CreateEnrollmentCommand, Data.Models.Enrollment>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public CreateEnrollmentCommandHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<Response<Data.Models.Enrollment>> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            // Buisness logic
            try
            {
                if (request.StudentId <= 0) throw new ArgumentNullException(nameof(request.StudentId));
                if (request.CourseId <= 0) throw new ArgumentNullException(nameof(request.CourseId));

                var student = _context.Students.FirstOrDefault(x => x.Id == request.StudentId && x.SoftDeleted == null);
                if (student == null) throw new Exception("Student not found.");

                var course = _context.Courses.FirstOrDefault(x => x.Id == request.CourseId && x.SoftDeleted == null);
                if (course == null) throw new Exception("Course not found.");

                await _context.AddAsync(new Data.Models.Enrollment()
                {
                    Student = student,
                    Course = course,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                });

                await _context.SaveChangesAsync();

                return await Task.FromResult(Response.Ok<Data.Models.Enrollment>("Enrollment created."));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Response.Fail<Data.Models.Enrollment>(ex.Message));
            }
        }
    }
}
