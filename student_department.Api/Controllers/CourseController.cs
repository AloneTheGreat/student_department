using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_department.Application.Features.Courses.Commands.CreateCourse;
using student_department.Application.Features.Courses.Queries.GetCoursesList;
using student_department.Application.Features.Departments.Commands.CreateDepartment;
using student_department.Application.Features.Departments.Queries.GetDepartmentsList;
using student_department.Application.Features.Departments.Queries.GetDepartmentsListWithStudents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_department.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCourses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CourseListVm>>> GetAllCourses()
        {
            var dtos = await _mediator.Send(new GetCourseListQuery());
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCourse")]
        public async Task<ActionResult<CreateCourseCommandResponse>> Create([FromBody] CreateCourseCommand createCourseCommand)
        {
            var response = await _mediator.Send(createCourseCommand);
            return Ok(response);
        }
    }
}
