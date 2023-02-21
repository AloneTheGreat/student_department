using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Departments.Queries.GetDepartmentsListWithStudents
{
    public class GetDepartmentsListWithStudentsQuery : IRequest<List<DepartmentStudentListVm>>
    {
    }
}
