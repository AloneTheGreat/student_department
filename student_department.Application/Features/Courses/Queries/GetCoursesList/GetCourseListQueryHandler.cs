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
        private readonly IAsyncRepository<Teacher> _teacherRepository;
        private readonly IAsyncRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public GetCourseListQueryHandler(IMapper mapper, IAsyncRepository<Course> courseRepository, IAsyncRepository<Teacher> teacherRepository, IAsyncRepository<Department> departmentRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<List<CourseListVm>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var allCourses = (await _courseRepository.ListAllAsync()).OrderBy(x => x.CourseName);
            foreach (var course in allCourses)
            {
                var teacher = await _teacherRepository.GetByIdAsync(course.TeacherId);
                course.Teacher = teacher;
                var department = await _departmentRepository.GetByIdAsync(course.Teacher.DepartmentId);
                course.Teacher.Department = department;
            }
            return _mapper.Map<List<CourseListVm>>(allCourses);
        }
    }
}
