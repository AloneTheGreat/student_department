using MediatR;
using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherCommand : IRequest<Guid>
    {
        public string TeacherName { get; set; }
        public Guid DepartmentId { get; set; }

    }
}