using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseDto
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
