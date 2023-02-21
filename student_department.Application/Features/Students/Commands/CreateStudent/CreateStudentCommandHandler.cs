using AutoMapper;
using MediatR;
using student_department.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using student_department.Application.Contracts.Persistence;

namespace student_department.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IMapper mapper, IStudentRepository eventRepository)
        {
            _mapper = mapper;
            _studentRepository = eventRepository;
        }

        public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateStudentCommandValidator(_studentRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var student = new Student() {};

            student = _mapper.Map<Student>(request);

            student = await _studentRepository.AddAsync(student);

            return student.StudentId;
        }
    }
}
