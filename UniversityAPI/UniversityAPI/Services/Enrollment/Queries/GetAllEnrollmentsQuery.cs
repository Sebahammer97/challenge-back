using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Enrollment;

namespace UniversityAPI.Services.Enrollment.Queries
{
    public class GetAllEnrollmentsQuery : GetAllEnrollmentsRequest, IRequest<List<Data.Models.Enrollment>> { }

    public class GetAllEnrollmentQueryHandler : IRequestHandler<GetAllEnrollmentsQuery, List<Data.Models.Enrollment>>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public GetAllEnrollmentQueryHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<List<Data.Models.Enrollment>> Handle(GetAllEnrollmentsQuery request, CancellationToken cancellationToken)
        {
            // Buisness logic
            var enrollments = _context.Enrollments.Where(x => x.SoftDeleted == null);

            if (request.Id != null)
                return await enrollments.Where(x => x.Id == request.Id).ToListAsync();
            if (request.CourseId != null)
                enrollments = enrollments.Where(x => x.CourseId == request.CourseId);
            if (request.StudentId != null)
                enrollments = enrollments.Where(x => x.StudentId == request.StudentId);

            return await enrollments.ToListAsync();
        }
    }
}
