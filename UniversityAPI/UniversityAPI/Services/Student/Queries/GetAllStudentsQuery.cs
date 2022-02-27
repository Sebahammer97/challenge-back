using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Student;

namespace UniversityAPI.Services.Student.Queries
{
    public class GetAllStudentsQuery : GetAllStudentsRequest, IRequest<List<Data.Models.Student>> { }

    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<Data.Models.Student>>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public GetAllStudentsQueryHandler(UniversityContext context)
        { 
            _context = context;
        }

        public async Task<List<Data.Models.Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            // Buisness logic
            var students = _context.Students.Where(x => x.SoftDeleted == null);

            if (request.Id != null)
                return await students.Where(x => x.Id == request.Id).ToListAsync();
            if (request.FirstName != null)
                students = students.Where(x => x.FirstName.Contains(request.FirstName));
            if (request.MidName != null)
                students = students.Where(x => x.MidName.Contains(request.MidName));
            if (request.LastName != null)
                students = students.Where(x => x.LastName.Contains(request.LastName));
            if (request.Birthday != null)
                students = students.Where(x => x.Birthday == request.Birthday);

            return await students.ToListAsync();
        }
    }
}
