using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Student;
using UniversityAPI.Services.Wrappers;

namespace UniversityAPI.Services.Student.Commands
{
    public class UpdateStudentCommand : UpdateInstructorRequest, IRequestWrapper<Data.Models.Student> { }

    public class UpdateStudentCommandHandler : IHandlerWrapper<UpdateStudentCommand, Data.Models.Student>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public UpdateStudentCommandHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<Response<Data.Models.Student>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            // Buisness logic
            try
            {
                var student = _context.Students.FirstOrDefault(x => x.Id == request.Id && x.SoftDeleted == null);

                if (student == null) throw new Exception("Student not found.");

                if (!string.IsNullOrEmpty(request.FirstName) && request.FirstName != student.FirstName)
                    student.FirstName = request.FirstName;
                if (!string.IsNullOrEmpty(request.MidName) && request.MidName != student.MidName)
                    student.MidName = request.MidName;
                if (!string.IsNullOrEmpty(request.LastName) && request.LastName != student.LastName)
                    student.LastName = request.LastName;
                if (request.Birthday != null && request.Birthday != student.Birthday)
                    student.Birthday = request.Birthday;

                student.UpdatedOn = DateTime.Now;

                await _context.SaveChangesAsync();

                return await Task.FromResult(Response.Ok<Data.Models.Student>("Student updated."));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Response.Fail<Data.Models.Student>(ex.Message));
            }
        }
    }
}
