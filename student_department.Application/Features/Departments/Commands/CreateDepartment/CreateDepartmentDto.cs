using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentDto
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
