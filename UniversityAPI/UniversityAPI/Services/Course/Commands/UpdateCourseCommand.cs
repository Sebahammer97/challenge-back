using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniversityAPI.Data.Context;
using UniversityAPI.Services.Requests.Course;
using UniversityAPI.Services.Wrappers;

namespace UniversityAPI.Services.Course.Commands
{
    public class UpdateCourseCommand : UpdateCourseRequest, IRequestWrapper<Data.Models.Course> { }

    public class UpdateCourseCommandHandler : IHandlerWrapper<UpdateCourseCommand, Data.Models.Course>
    {
        // Dependency injection
        private readonly UniversityContext _context;

        public UpdateCourseCommandHandler(UniversityContext context)
        {
            _context = context;
        }

        public async Task<Response<Data.Models.Course>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            // Buisness logic
            try
            {
                var course = _context.Courses.FirstOrDefault(x => x.Id == request.Id);

                if (course == null) throw new Exception("Course not found.");

                if (!string.IsNullOrEmpty(request.Title) && request.Title != course.Title)
                    course.Title = request.Title;
                if (request.Hours > 0 && request.Hours != course.Hours)
                    course.Hours = request.Hours;
                if (request.Credits > 0 && request.Credits != course.Credits)
                    course.Credits = request.Credits;
                if (request.InstructorId > 0 && request.InstructorId != course.InstructorId)
                {
                    var instructor = _context.Instructors.FirstOrDefault(x => x.Id == request.InstructorId && x.SoftDeleted == null);
                    
                    if (instructor == null) throw new Exception("Instructor not found.");
                    
                    course.InstructorId = instructor.Id;
                }

                course.UpdatedOn = DateTime.Now;

                await _context.SaveChangesAsync();

                return await Task.FromResult(Response.Ok<Data.Models.Course>("Course updated."));

            }
            catch (Exception ex)
            {
                return await Task.FromResult(Response.Fail<Data.Models.Course>(ex.Message));
            }
        }
    }
}
