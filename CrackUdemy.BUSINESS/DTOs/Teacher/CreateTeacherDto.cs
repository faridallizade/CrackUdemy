using App.BUSINESS.DTOs.Student;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BUSINESS.DTOs.Teacher
{
    public class CreateTeacherDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? Age { get; set; }
    }
    public class TeacherCreateDtoValidator : AbstractValidator<CreateTeacherDto>
    {
        public TeacherCreateDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name required")
               .MinimumLength(3).WithMessage("Name must be at least 3 chraracters.")
               .MaximumLength(100).WithMessage("Name must be shorter than 55 characters");
            RuleFor(x => x.Surname)
               .NotEmpty().WithMessage("Surname required.")
               .MinimumLength(3).WithMessage("SurName must be at least 3 chraracters.")
               .MaximumLength(100).WithMessage("SurName must be shorter than 55 characters");
            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("Age required");
        }
    }
}
