using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityAPI.Data.Models;
using UniversityAPI.Services;
using UniversityAPI.Services.Student.Commands;
using UniversityAPI.Services.Student.Queries;

namespace UniversityAPI.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController : Controller
    {
        private readonly IMediator mediator;

        public StudentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: Students
        [HttpGet]
        public Task<List<Student>> Index([FromBody] GetAllStudentsQuery query)
        {
            return mediator.Send(query);
        }

        // POST: Student
        [HttpPost]
        public Task<Response<Student>> Index([FromBody] CreateStudentCommand command)
        {
            return mediator.Send(command);
        }

        // PUT: Student
        [HttpPut]
        public Task<Response<Student>> Index([FromBody] UpdateStudentCommand command)
        {
            return mediator.Send(command);
        }

        // DELETE: Student
        [HttpDelete]
        public Task<Response<Student>> Index([FromBody] DeleteStudentCommand command)
        {
            return mediator.Send(command);
        }
    }
}
