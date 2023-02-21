using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentcommand : IRequest<Unit>
    {
        public Guid StudentId { get; set; }
    }
}
