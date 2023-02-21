using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_department.Application.Features.Departments.Commands.CreateDepartment;
using student_department.Application.Features.Departments.Queries.GetDepartmentsList;
using student_department.Application.Features.Departments.Queries.GetDepartmentsListWithStudents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_department.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllDepartments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DepartmentListVm>>> GetAllDepartments()
        {
            var dtos = await _mediator.Send(new GetDepartmentListQuery());
            return Ok(dtos);
        }

        [HttpGet("allwithstudents", Name = "GetDepartmentsWithStudents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DepartmentStudentListVm>>> GetDepartmentsWithStudents()
        {
            GetDepartmentsListWithStudentsQuery getDepartmentsListWithStudentsQuery = new GetDepartmentsListWithStudentsQuery() {};

            var dtos = await _mediator.Send(getDepartmentsListWithStudentsQuery);
            return Ok(dtos);
        }

        [HttpPost(Name = "AddDepartment")]
        public async Task<ActionResult<CreateDepartmentCommandResponse>> Create([FromBody] CreateDepartmentCommand createDepartmentCommand)
        {
            var response = await _mediator.Send(createDepartmentCommand);
            return Ok(response);
        }
    }
}
