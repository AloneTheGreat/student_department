using AutoMapper;
using MediatR;
using student_department.Application.Contracts.Persistence;
using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace student_department.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, CreateDepartmentCommandResponse>
    {
        private readonly IAsyncRepository<Department> _departmendRepository;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(IMapper mapper, IAsyncRepository<Department> departmendRepository)
        {
            _departmendRepository = departmendRepository;
            _mapper = mapper;
        }

        public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommand Request, CancellationToken cancellationToken)
        {
            var createDepartmentCommandResponse = new CreateDepartmentCommandResponse();

            var validator = new CreateDepartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(Request);

            if (validationResult.Errors.Count > 0)
            {
                createDepartmentCommandResponse.Success = false;
                createDepartmentCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createDepartmentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createDepartmentCommandResponse.Success)
            {
                var department = new Department() { DepartmentName = Request.DepartmentName };
                department = await _departmendRepository.AddAsync(department);
                createDepartmentCommandResponse.Department = _mapper.Map<CreateDepartmentDto>(department);
            }

            return createDepartmentCommandResponse;
        }
    }
}
