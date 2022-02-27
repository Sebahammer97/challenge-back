using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityAPI.Data.Models;
using UniversityAPI.Services;
using UniversityAPI.Services.Course.Commands;
using UniversityAPI.Services.Course.Queries;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("courses")]
    public class CourseController : Controller
    {
        private readonly IMediator mediator;

        public CourseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Courses
        [HttpGet]
        public Task<List<Course>> Index([FromBody] GetAllCoursesQuery query)
        {
            return mediator.Send(query);
        }

        // POST: Course
        [HttpPost]
        public Task<Response<Course>> Index([FromBody] CreateCourseCommand command)
        {
            return mediator.Send(command);
        }

        // PUT: Course
        [HttpPut]
        public Task<Response<Course>> Index([FromBody] UpdateCourseCommand command)
        {
            return mediator.Send(command);
        }

        // Delete: Course
        [HttpDelete]
        public Task<Response<Course>> Index([FromBody] DeleteCourseCommand command)
        {
            return mediator.Send(command);
        }
    }
}
