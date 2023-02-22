using AutoMapper;
using MediatR;
using student_department.Application.Contracts.Persistence;
using student_department.Application.Features.Students.Commands.CreateStudent;
using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace student_department.Application.Features.Teachers.Commands.CreateTeacher
{
    internal class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, Guid>
    {
        private readonly IAsyncRepository<Teacher> _teacherRepository;
        private readonly IMapper _mapper;

        public CreateTeacherCommandHandler(IMapper mapper, IAsyncRepository<Teacher> teacherRepository)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
        }

        public async Task<Guid> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTeacherCommandValidator(_teacherRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var teacher = new Teacher() { };

            teacher = _mapper.Map<Teacher>(request);

            teacher = await _teacherRepository.AddAsync(teacher);

            return teacher.TeacherId;
        }
    }
}