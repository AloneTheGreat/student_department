using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_department.Application.Features.Students.Commands.CreateStudent;
using student_department.Application.Features.Students.Commands.DeleteStudent;
using student_department.Application.Features.Students.Commands.UpdateStudent;
using student_department.Application.Features.Students.Queries.GetStudentDetail;
using student_department.Application.Features.Students.Queries.GetStudentsList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace student_department.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<StudentListVm>>> GetAllStudents()
        {
            var dtos = await _mediator.Send(new GetStudentListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        public async Task<ActionResult<StudentDetailVm>> GetStudentById(Guid id)
        {
            var getStudentDetailQuery = new GetStudentdetailQuery() { StudentId = id };
            return Ok(await _mediator.Send(getStudentDetailQuery));
        }

        [HttpPost(Name = "AddStudent")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateStudentCommand createStudentCommand)
        {
            var id = await _mediator.Send(createStudentCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateStudentCommand updateStudentCommand)
        {
            await _mediator.Send(updateStudentCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteStudentCommand = new DeleteStudentcommand() { StudentId = id };
            await _mediator.Send(deleteStudentCommand);
            return NoContent();
        }

    }
}
