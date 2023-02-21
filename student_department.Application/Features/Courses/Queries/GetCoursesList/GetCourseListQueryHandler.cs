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
using student_department.Application.Features.Courses.Queries.GetCoursesList;

namespace student_department.Application.Features.Courses.Queries.GetCoursesList
{
    public class GetCourseListQueryHandler : IRequestHandler<GetCourseListQuery, List<CourseListVm>>
    {
        private readonly IAsyncRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseListQueryHandler(IMapper mapper, IAsyncRepository<Course> courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<List<CourseListVm>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var allCourses = (await _courseRepository.ListAllAsync()).OrderBy(x => x.CourseName);
            
            return _mapper.Map<List<CourseListVm>>(allCourses);
        }
    }
}
