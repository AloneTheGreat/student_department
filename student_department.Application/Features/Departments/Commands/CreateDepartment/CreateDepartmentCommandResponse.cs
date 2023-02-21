using student_department.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandResponse : BaseResponse
    {
        public CreateDepartmentCommandResponse() : base()
        {

        }

        public CreateDepartmentDto Department { get; set; }
    }
}
