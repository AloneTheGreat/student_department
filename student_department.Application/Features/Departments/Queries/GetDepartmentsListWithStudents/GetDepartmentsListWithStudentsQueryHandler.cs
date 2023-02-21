using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using student_department.Application.Contracts.Persistence;

namespace student_department.Application.Features.Departments.Queries.GetDepartmentsListWithStudents
{
    public class GetDepartmentsListWithStudentsQueryHandler : IRequestHandler<GetDepartmentsListWithStudentsQuery, List<DepartmentStudentListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public GetDepartmentsListWithStudentsQueryHandler(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<List<DepartmentStudentListVm>> Handle(GetDepartmentsListWithStudentsQuery request, CancellationToken cancellationToken)
        {
            var list = await _departmentRepository.GetDepartmentsWithStudents();
            return _mapper.Map<List<DepartmentStudentListVm>>(list);
        }
    }
}
