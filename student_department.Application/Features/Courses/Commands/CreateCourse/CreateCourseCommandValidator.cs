using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace student_department.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(p => p.CourseName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");
        }
    }
}
