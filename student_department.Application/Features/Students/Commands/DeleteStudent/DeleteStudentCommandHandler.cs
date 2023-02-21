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

namespace student_department.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentcommand, Unit>
    {
        private readonly IAsyncRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public DeleteStudentCommandHandler(IMapper mapper, IAsyncRepository<Student> studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(DeleteStudentcommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _studentRepository.GetByIdAsync(request.StudentId);

            if (eventToDelete == null)
            {
                throw new NotFoundException(nameof(Student), request.StudentId);
            }

            await _studentRepository.DeleteAsync(eventToDelete);

            return Unit.Value;
        }
    }
}
