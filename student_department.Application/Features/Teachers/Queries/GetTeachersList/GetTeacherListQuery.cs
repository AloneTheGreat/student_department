using MediatR;
using student_department.Application.Features.Teachers.Queries.GetTeachersList;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Teachers.Queries.GetTeachersList
{
    public class GetTeacherListQuery : IRequest<List<TeacherListVm>>
    {
    }
}
