using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_department.Application.Features.Departments.Commands.CreateDepartment;
using student_department.Application.Features.Departments.Queries.GetDepartmentsList;
using student_department.Application.Features.Departments.Queries.GetDepartmentsListWithStudents;
using student_department.Application.Features.Teachers.Queries.GetTeachersList;
using student_department.Application.Features.Teachers.Commands.CreateTeacher;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_department.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllTeachers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TeacherListVm>>> GetAllTeachers()
        {
            var dtos = await _mediator.Send(new GetTeacherListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddTeacher")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTeacherCommand createTeacherCommand)
        {
            var response = await _mediator.Send(createTeacherCommand);
            return Ok(response);
        }
    }
}
