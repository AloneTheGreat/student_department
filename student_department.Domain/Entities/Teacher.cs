using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Domain.Entities
{
    public class Teacher
    {
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
