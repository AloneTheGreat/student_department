using AutoMapper;
using MediatR;
using student_department.Application.Contracts.Persistence;
using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace student_department.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreateCourseCommandResponse>
    {
        private readonly IAsyncRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(IMapper mapper, IAsyncRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CreateCourseCommandResponse> Handle(CreateCourseCommand Request, CancellationToken cancellationToken)
        {
            var createCourseCommandResponse = new CreateCourseCommandResponse();

            var validator = new CreateCourseCommandValidator();
            var validationResult = await validator.ValidateAsync(Request);

            if (validationResult.Errors.Count > 0)
            {
                createCourseCommandResponse.Success = false;
                createCourseCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCourseCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCourseCommandResponse.Success)
            {
                var course = new Course() { CourseName = Request.CourseName, DepartmentId = Request.DepartmentId };
                course = await _courseRepository.AddAsync(course);
                createCourseCommandResponse.Course = _mapper.Map<CreateCourseDto>(course);
            }

            return createCourseCommandResponse;
        }
    }
}
