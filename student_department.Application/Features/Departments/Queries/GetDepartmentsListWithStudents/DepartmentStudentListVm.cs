using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Departments.Queries.GetDepartmentsListWithStudents
{
    public class DepartmentStudentListVm
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<DepartmentStudentDto> Students { get; set; }
    }
}
