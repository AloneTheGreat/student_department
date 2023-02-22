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
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseListQueryHandler(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<List<CourseListVm>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var allCourses = (await _courseRepository.GetAllWithDeatails()).OrderBy(x => x.CourseName);
            
            var result= _mapper.Map<List<CourseListVm>>(allCourses);
            return result;
        }
    }
}
