using App.BUSINESS.DTOs.BaseDtos;
using App.BUSINESS.DTOs.Category;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BUSINESS.DTOs.Brand
{
    public class UpdateCategoryDto:BaseEntityDto
    {
        public string? Name { get; set; }
        public IFormFile? LogoImg { get; set; }
        public int? ParentCategoryId { get; set; }



    }
    public class CategoryUpdateDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Required")
                .MinimumLength(3).WithMessage("Category name must be at least 3 chraracters.")
                .MaximumLength(100).WithMessage("Category name must be shorter than 55 characters.");
        }
    }
}
