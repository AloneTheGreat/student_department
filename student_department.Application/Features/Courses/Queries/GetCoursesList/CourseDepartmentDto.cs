using System;
using System.Collections.Generic;

namespace student_department.Application.Features.Courses.Queries.GetCoursesList
{
    public class CourseDepartmentDto
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<CourseStudentDto> Students { get; set; }
    }
}