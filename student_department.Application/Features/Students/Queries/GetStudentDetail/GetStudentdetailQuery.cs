using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Students.Queries.GetStudentDetail
{
    public class GetStudentdetailQuery : IRequest<StudentDetailVm>
    {
        public Guid StudentId { get; set; }
    }
}
