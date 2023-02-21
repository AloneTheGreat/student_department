using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Students.Queries.GetStudentsList
{
    public class GetStudentListQuery : IRequest<List<StudentListVm>>
    {
    }
}
