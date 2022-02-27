using System;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Student;
using UniversityAPI.Services.Wrappers;

namespace UniversityAPI.Services.Student.Commands
{
    public class CreateStudentCommand : CreateInstructorRequest, IRequestWrapper<Data.Models.Student> { }

    public class CreateStudentCommandHandler : IHandlerWrapper<CreateStudentCommand, Data.Models.Student>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public CreateStudentCommandHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<Response<Data.Models.Student>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            // Buisness logic
            try
            {
                if (string.IsNullOrEmpty(request.FirstName)) throw new ArgumentNullException(nameof(request.FirstName));
                if (string.IsNullOrEmpty(request.LastName)) new ArgumentNullException(nameof(request.LastName));
                if (request.Birthday == null) throw new ArgumentNullException(nameof(request.Birthday));

                await _context.AddAsync(new Data.Models.Student()
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

                return await Task.FromResult(Response.Ok<Data.Models.Student>("Student created."));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Response.Fail<Data.Models.Student>(ex.Message));
            }
        }
    }
}
