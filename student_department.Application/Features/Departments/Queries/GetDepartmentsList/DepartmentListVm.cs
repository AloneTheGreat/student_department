using student_department.Application.Features.Departments.Queries.GetDepartmentsListWithStudents;
using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Departments.Queries.GetDepartmentsList
{
    public class DepartmentListVm
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set;}
        public ICollection<DepartmentTeacherDto> Teachers { get; set; }
    }
}
