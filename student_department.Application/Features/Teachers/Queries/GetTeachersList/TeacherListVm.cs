using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Teachers.Queries.GetTeachersList
{
    public class TeacherListVm
    {
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }
        public TeacherDepartmentDto Department { get; set; }
        public ICollection<TeacherCourseDto> Courses { get; set; }
    }
}
