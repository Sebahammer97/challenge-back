using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Enrollment;
using UniversityAPI.Services.Wrappers;

namespace UniversityAPI.Services.Enrollment.Commands
{
    public class DeleteEnrollmentCommand : DeleteEnrollmentRequest, IRequestWrapper<Data.Models.Enrollment> { }

    public class DeleteEnrolmmentCommandHandler : IHandlerWrapper<DeleteEnrollmentCommand, Data.Models.Enrollment>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public DeleteEnrolmmentCommandHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<Response<Data.Models.Enrollment>> Handle(DeleteEnrollmentCommand request, CancellationToken cancellationToken)
        {
            // Buisness logic
            try
            {
                var enrollment = _context.Enrollments.FirstOrDefault(x => x.Id == request.Id);

                if (enrollment == null) throw new Exception("Enrollment not found");

                enrollment.SoftDeleted = DateTime.Now;
                enrollment.UpdatedOn = DateTime.Now;

                await _context.SaveChangesAsync();

                return await Task.FromResult(Response.Ok<Data.Models.Enrollment>("Enrollment deleted."));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Response.Fail<Data.Models.Enrollment>(ex.Message));
            }
        }
    }
}
