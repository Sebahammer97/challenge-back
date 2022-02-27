using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Course;

namespace UniversityAPI.Services.Course.Queries
{
    public class GetAllCoursesQuery : GetAllCoursesRequest, IRequest<List<Data.Models.Course>> { }
    
    public class GetAllCroursesQueryHandler : IRequestHandler<GetAllCoursesQuery, List<Data.Models.Course>> 
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public GetAllCroursesQueryHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<List<Data.Models.Course>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            // Buisness logic
            var courses = _context.Courses.Where(x => x.SoftDeleted == null);

            if (request.Id != null)
                return await courses.Where(x => x.Id == request.Id).ToListAsync();
            if (request.Title != null)
                courses = courses.Where(x => x.Title.Contains(request.Title));
            if (request.Hours != null)
                courses = courses.Where(x => x.Hours == request.Hours);
            if (request.Credits != null)
                courses = courses.Where(x => x.Credits == request.Credits);
            if (request.InstructorId != null)
                courses = courses.Where(x => x.InstructorId == request.InstructorId);

            return await courses.ToListAsync();
        }
    }
}
