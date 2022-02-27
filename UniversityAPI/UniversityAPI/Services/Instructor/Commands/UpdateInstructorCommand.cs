using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Instructor;
using UniversityAPI.Services.Wrappers;

namespace UniversityAPI.Services.Instructor.Commands
{
    public class UpdateInstructorCommand : UpdateInstructorRequest, IRequestWrapper<Data.Models.Instructor> { }

    public class UpdateIsntructorCommandHandler : IHandlerWrapper<UpdateInstructorCommand, Data.Models.Instructor>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public UpdateIsntructorCommandHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<Response<Data.Models.Instructor>> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
        {
            // Buisness logic
            try
            {
                var instructor = _context.Instructors.FirstOrDefault(x => x.Id == request.Id && x.SoftDeleted == null);

                if (instructor == null) throw new Exception("Instructor not found.");

                if (!string.IsNullOrEmpty(request.FirstName) && request.FirstName != instructor.FirstName)
                    instructor.FirstName = request.FirstName;
                if (!string.IsNullOrEmpty(request.MidName) && request.MidName != instructor.MidName)
                    instructor.MidName = request.MidName;
                if (!string.IsNullOrEmpty(request.LastName) && request.LastName != instructor.LastName)
                    instructor.LastName = request.LastName;
                if (request.Birthday != null && request.Birthday != instructor.Birthday)
                    instructor.Birthday = request.Birthday;

                instructor.UpdatedOn = DateTime.Now;

                await _context.SaveChangesAsync();

                return await Task.FromResult(Response.Ok<Data.Models.Instructor>("Instructor updated."));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Response.Fail<Data.Models.Instructor>(ex.Message));
            }
        }
    }
}
