using student_department.Domain.Entities;
using System.Collections.Generic;
using System;

namespace student_department.Application.Features.Courses.Queries.GetCoursesList
{
    public class CourseTeacherDto
    {
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }
        public CourseDepartmentDto Department { get; set; }
    }
}