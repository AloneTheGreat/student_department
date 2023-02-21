using AutoMapper;
using MediatR;
using student_department.Application.Contracts.Persistence;
using student_department.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using student_department.Domain.Entities;

namespace student_department.Application.Features.Students.Queries.GetStudentDetail
{
    public class GetStudentDetailQueryHandler : IRequestHandler<GetStudentdetailQuery, StudentDetailVm>
    {
        private readonly IAsyncRepository<Student> _studentRepository;
        private readonly IAsyncRepository<Department> _departmentRepository;
        private readonly IAsyncRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public GetStudentDetailQueryHandler(IMapper mapper, IAsyncRepository<Student> studentRepository, IAsyncRepository<Department> departmentRepository, IAsyncRepository<Course> courseRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<StudentDetailVm> Handle(GetStudentdetailQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.StudentId);
            var studentDetailDto = _mapper.Map<StudentDetailVm>(student);

            var department = await _departmentRepository.GetByIdAsync(student.DepartmentId);

            if (department == null)
            {
                throw new NotFoundException(nameof(Student), request.StudentId);
            }
            studentDetailDto.Department = _mapper.Map<DepartmentDto>(department);

            return studentDetailDto;
        }
    }
}
