using System;

namespace student_department.Application.Features.Courses.Queries.GetCoursesList
{
    public class CourseDepartmentDto
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}