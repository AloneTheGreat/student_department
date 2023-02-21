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

namespace student_department.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly IAsyncRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IMapper mapper, IAsyncRepository<Student> studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {

            var studentToUpdate = await _studentRepository.GetByIdAsync(request.StudentId);

            if (studentToUpdate == null)
            {
                throw new NotFoundException(nameof(Student), request.StudentId);
            }

            var validator = new UpdateStudentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, studentToUpdate);

            await _studentRepository.UpdateAsync(studentToUpdate);

            return Unit.Value;
        }
    }
}
