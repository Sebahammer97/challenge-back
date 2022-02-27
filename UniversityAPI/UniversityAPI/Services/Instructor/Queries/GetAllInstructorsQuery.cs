using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Instructor;

namespace UniversityAPI.Services.Instructor.Queries
{
    public class GetAllInstrcutorsQuery : GetAllInstructorsRequest, IRequest<List<Data.Models.Instructor>> { }

    public class GetAllInstructorsQueryHandler : IRequestHandler<GetAllInstrcutorsQuery, List<Data.Models.Instructor>>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public GetAllInstructorsQueryHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<List<Data.Models.Instructor>> Handle(GetAllInstrcutorsQuery request, CancellationToken cancellationToken)
        {
            // Buisness logic
            var instructors = _context.Instructors.Where(x => x.SoftDeleted == null);

            if (request.Id != null)
                return await instructors.Where(x => x.Id == request.Id).ToListAsync();
            if (request.FirstName != null)
                instructors = instructors.Where(x => x.FirstName.Contains(request.FirstName));
            if (request.MidName != null)
                instructors = instructors.Where(x => x.MidName.Contains(request.MidName));
            if (request.LastName != null)
                instructors = instructors.Where(x => x.LastName.Contains(request.LastName));
            if (request.Birthday != null)
                instructors = instructors.Where(x => x.Birthday == request.Birthday);

            return await instructors.ToListAsync();
        }
    }
}
