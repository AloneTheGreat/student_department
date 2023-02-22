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
using student_department.Application.Features.Teachers.Queries.GetTeachersList;

namespace student_department.Application.Features.Teachers.Queries.GetTeachersList
{
    public class GetTeacherListQueryHandler : IRequestHandler<GetTeacherListQuery, List<TeacherListVm>>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public GetTeacherListQueryHandler(IMapper mapper, ITeacherRepository teacherRepository)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        public async Task<List<TeacherListVm>> Handle(GetTeacherListQuery request, CancellationToken cancellationToken)
        {
            var allteachers = (await _teacherRepository.GetAllTeachersWithCourses()).OrderBy(x => x.TeacherName);
            return _mapper.Map<List<TeacherListVm>>(allteachers);
        }
    }
}
