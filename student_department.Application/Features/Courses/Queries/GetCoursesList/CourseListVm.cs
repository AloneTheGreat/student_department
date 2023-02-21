using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Courses.Queries.GetCoursesList
{
    public class CourseListVm
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set;}
        public Guid DepartmentId { get; set;}
    }
}
