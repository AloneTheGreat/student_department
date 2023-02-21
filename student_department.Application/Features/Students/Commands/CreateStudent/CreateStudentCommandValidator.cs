using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using student_department.Application.Contracts.Persistence;

namespace student_department.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        private readonly IStudentRepository _StudentRepository;
        public CreateStudentCommandValidator(IStudentRepository studentRepository)
        {
            _StudentRepository = studentRepository;

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress();

            RuleFor(e => e)
                .MustAsync(StudentEmailUnique)
                .WithMessage("A Student with the same Email already exists.");
        }

        private async Task<bool> StudentEmailUnique(CreateStudentCommand e, CancellationToken token)
        {
            return !(await _StudentRepository.IsStudentEmailUnique(e.Email));
        }
    }
}
