using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Domain.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
