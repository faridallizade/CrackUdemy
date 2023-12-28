using App.BUSINESS.DTOs.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BUSINESS.DTOs.Course
{
    public class CreateCourseDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? TeacherId { get; set; }
    }
    public class CourseCreateDtoValidator : AbstractValidator<CreateCourseDto>
    {
        public CourseCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Name Required")
                .MinimumLength(3).WithMessage("Course name must be at least 3 chraracters.")
                .MaximumLength(100).WithMessage("Course name must be shorter than 55 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cant be empty!")
                .MinimumLength(15).WithMessage("Description must contains at least 15 characters.");
        }
    }
}
