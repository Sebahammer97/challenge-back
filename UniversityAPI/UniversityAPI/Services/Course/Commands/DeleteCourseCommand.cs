using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Course;
using UniversityAPI.Services.Wrappers;

namespace UniversityAPI.Services.Course.Commands
{
    public class DeleteCourseCommand : DeleteCourseRequest, IRequestWrapper<Data.Models.Course> { }
    
    public class DeleteCrouseCommandHandler : IHandlerWrapper<DeleteCourseCommand, Data.Models.Course>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public DeleteCrouseCommandHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<Response<Data.Models.Course>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            // Buisness logic
            try
            {
                var course = _context.Courses.FirstOrDefault(x => x.Id == request.Id);

                if (course == null) throw new Exception("Course not found.");

                course.SoftDeleted = DateTime.Now;
                course.UpdatedOn = DateTime.Now;

                await _context.SaveChangesAsync();

                return await Task.FromResult(Response.Ok<Data.Models.Course>("Course deleted."));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Response.Fail<Data.Models.Course>(ex.Message));
            }
        }
    }
}
