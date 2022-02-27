using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityAPI.Data.Models;
using UniversityAPI.Services;
using UniversityAPI.Services.Enrollment.Commands;
using UniversityAPI.Services.Enrollment.Queries;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("enrollments")]
    public class EnrollmentController : Controller
    {
        private readonly IMediator mediator;
        public EnrollmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Enrollments
        [HttpGet]
        public Task<List<Enrollment>> Index([FromBody] GetAllEnrollmentsQuery query)
        {
            return mediator.Send(query);
        }

        // POST: Enrollment
        [HttpPost]
        public Task<Response<Enrollment>> Index([FromBody] CreateEnrollmentCommand command)
        {
            return mediator.Send(command);
        }
        
        // PUT: Enrollment
        [HttpPut]
        public Task<Response<Enrollment>> Index([FromBody] UpdateEnrollmentCommand command)
        {
            return mediator.Send(command);
        }

        [HttpDelete]
        // Delete: Enrollment
        public Task<Response<Enrollment>> Index([FromBody] DeleteEnrollmentCommand command)
        {
            return mediator.Send(command);
        }
    }
}
