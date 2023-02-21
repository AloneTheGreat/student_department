using MediatR;
using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace student_department.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }

        public override string ToString()
        {
            return $"Student name: {FirstName} {LastName}; Email: {Email};";
        }
    }
}
