using FluentValidation;
using student_department.Application.Contracts.Persistence;
using student_department.Application.Features.Students.Commands.CreateStudent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using student_department.Domain.Entities;

namespace student_department.Application.Features.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommand>
    {
        private readonly IAsyncRepository<Teacher> _teacherRepository;
        public CreateTeacherCommandValidator(IAsyncRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;

            RuleFor(p => p.TeacherName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }

    }
}