using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Enrollment;
using UniversityAPI.Services.Wrappers;

namespace UniversityAPI.Services.Enrollment.Commands
{
    public class UpdateEnrollmentCommand : UpdateEnrollmentRequest, IRequestWrapper<Data.Models.Enrollment> { }

    public class UpdateEnrollmentCommandHandler : IHandlerWrapper<UpdateEnrollmentCommand, Data.Models.Enrollment>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public UpdateEnrollmentCommandHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<Response<Data.Models.Enrollment>> Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            // Buisness logic
            try
            {
                var enrollment = _context.Enrollments.FirstOrDefault(x => x.Id == request.Id && x.SoftDeleted == null);

                if (enrollment == null) throw new Exception("Enrollment not found.");

                if (request.Grade > 0 && request.Grade != enrollment.Grade)
                    enrollment.Grade = request.Grade;

                await _context.SaveChangesAsync();

                return await Task.FromResult(Response.Ok<Data.Models.Enrollment>("Enrollment updated."));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Response.Fail<Data.Models.Enrollment>(ex.Message));
            }
        }
    }
}
