using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Student;
using UniversityAPI.Services.Wrappers;

namespace UniversityAPI.Services.Student.Commands
{
    public class DeleteStudentCommand : DeleteInstructoRequest, IRequestWrapper<Data.Models.Student> { }
    
    public class DeleteStudentCommandHandler : IHandlerWrapper<DeleteStudentCommand, Data.Models.Student>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public DeleteStudentCommandHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<Response<Data.Models.Student>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            // Buisness logic
            try
            {
                var student = _context.Students.FirstOrDefault(x => x.Id == request.Id);
                
                if (student == null) throw new Exception("Student not found.");

                student.SoftDeleted = DateTime.Now;
                student.UpdatedOn = DateTime.Now;

                await _context.SaveChangesAsync();

                return await Task.FromResult(Response.Ok<Data.Models.Student>("Student deleted."));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Response.Fail<Data.Models.Student>(ex.Message));
            }
        }
    }
}
