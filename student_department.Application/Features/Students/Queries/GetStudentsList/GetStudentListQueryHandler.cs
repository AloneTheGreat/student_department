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
        private readonly IAsyncRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentListQueryHandler(IMapper mapper, IAsyncRepository<Student> studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentListVm>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var allstudents = (await _studentRepository.ListAllAsync()).OrderBy(x => x.FirstName);
            return _mapper.Map<List<StudentListVm>>(allstudents);
        }
    }
}
