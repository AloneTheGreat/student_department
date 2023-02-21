using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<CreateDepartmentCommandResponse>
    {
        public string DepartmentName { get; set; }
    }
}
