using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityAPI.Data.Models;
using UniversityAPI.Services;
using UniversityAPI.Services.Instructor.Commands;
using UniversityAPI.Services.Instructor.Queries;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("instructors")]
    public class InstructorController : Controller
    {
        private readonly IMediator mediator;

        public InstructorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Instructors
        [HttpGet]
        public Task<List<Instructor>> Index([FromBody] GetAllInstrcutorsQuery query)
        {
            return mediator.Send(query);
        }

        // POST: Instructor
        [HttpPost]
        public Task<Response<Instructor>> Index([FromBody] CreateInstructorCommand command)
        {
            return mediator.Send(command);
        }

        // PUT: Instructor
        [HttpPut]
        public Task<Response<Instructor>> Index([FromBody] UpdateInstructorCommand command)
        {
            return mediator.Send(command);
        }

        // Delete: Instructor
        [HttpDelete]
        public Task<Response<Instructor>> Index([FromBody] DeleteInstrcutorCommand command)
        {
            return mediator.Send(command);
        }
    }
}
