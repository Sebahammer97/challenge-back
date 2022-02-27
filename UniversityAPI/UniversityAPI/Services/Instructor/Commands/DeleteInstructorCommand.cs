using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Instructor;
using UniversityAPI.Services.Wrappers;

namespace UniversityAPI.Services.Instructor.Commands
{
    public class DeleteInstrcutorCommand : DeleteInstructorRequest, IRequestWrapper<Data.Models.Instructor> { }

    public class DeleteStudentCommandHandler : IHandlerWrapper<DeleteInstrcutorCommand, Data.Models.Instructor>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public DeleteStudentCommandHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<Response<Data.Models.Instructor>> Handle(DeleteInstrcutorCommand request, CancellationToken cancellationToken)
        {
            // Buisness logic
            try
            {
                var instructor = _context.Instructors.FirstOrDefault(x => x.Id == request.Id);

                if (instructor == null) throw new Exception("Instructor not found.");

                instructor.SoftDeleted = DateTime.Now;
                instructor.UpdatedOn = DateTime.Now;

                await _context.SaveChangesAsync();

                return await Task.FromResult(Response.Ok<Data.Models.Instructor>("Instructor deleted."));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Response.Fail<Data.Models.Instructor>(ex.Message));
            }
        }
    }
}
