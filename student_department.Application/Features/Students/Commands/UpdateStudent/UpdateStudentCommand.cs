using MediatR;
using System;

namespace student_department.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<Unit>
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
    }
}