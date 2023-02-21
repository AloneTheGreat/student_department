using student_department.Domain.Entities;
using System.Collections.Generic;

namespace student_department.Application.Features.Students.Queries.GetStudentsList
{
    public class DepartmentCoursesDto
    {
        public string DepartmentName { get; set; }
        public ICollection<CoursesDto> Courses { get; set; }
    }
}