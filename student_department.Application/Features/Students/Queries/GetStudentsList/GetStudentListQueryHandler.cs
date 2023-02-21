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

namespace student_department.Application.Features.Students.Queries.GetStudentsList
{
    public class GetStudentListQueryHandler : IRequestHandler<GetStudentListQuery, List<StudentListVm>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentListQueryHandler(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentListVm>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var allstudents = (await _studentRepository.GetAllStudentsWithDepartmentAndCourses()).OrderBy(x => x.FirstName);
            return _mapper.Map<List<StudentListVm>>(allstudents);
        }
    }
}
