using System;

namespace student_department.Application.Features.Teachers.Queries.GetTeachersList
{
    public class TeacherCourseDto
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
    }
}