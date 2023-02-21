using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Domain.Entities
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
