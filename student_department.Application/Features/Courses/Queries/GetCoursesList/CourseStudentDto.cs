using System;

namespace student_department.Application.Features.Courses.Queries.GetCoursesList
{
    public class CourseStudentDto
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}