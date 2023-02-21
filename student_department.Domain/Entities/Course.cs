using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Domain.Entities
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
