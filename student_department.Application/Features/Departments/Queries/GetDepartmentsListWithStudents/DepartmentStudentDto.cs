using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Departments.Queries.GetDepartmentsListWithStudents
{
    public class DepartmentStudentDto
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
