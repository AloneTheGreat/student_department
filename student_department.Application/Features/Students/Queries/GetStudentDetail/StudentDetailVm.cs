using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Students.Queries.GetStudentDetail
{
    public class StudentDetailVm
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
