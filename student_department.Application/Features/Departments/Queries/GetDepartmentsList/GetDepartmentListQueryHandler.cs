using AutoMapper;
using MediatR;
using student_department.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using student_department.Domain.Entities;
using System.Linq;
using student_department.Application.Features.Departments.Queries.GetDepartmentsListWithStudents;

namespace student_department.Application.Features.Departments.Queries.GetDepartmentsList
{
    public class GetCourseListQueryHandler : IRequestHandler<GetDepartmentListQuery, List<DepartmentListVm>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetCourseListQueryHandler(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<List<DepartmentListVm>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var list = await _departmentRepository.GetDepartmentsWithCourses();
            return _mapper.Map<List<DepartmentListVm>>(list);
        }
    }
}
