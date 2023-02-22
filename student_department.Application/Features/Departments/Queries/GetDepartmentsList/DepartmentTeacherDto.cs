using System;

namespace student_department.Application.Features.Departments.Queries.GetDepartmentsList
{
    public class DepartmentTeacherDto
    {
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }
    }
}