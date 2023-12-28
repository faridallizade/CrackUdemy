using System;
using App.BUSINESS.DTOs.Brand;
using App.BUSINESS.DTOs.Category;
using App.BUSINESS.DTOs.Course;
using App.BUSINESS.DTOs.Student;
using App.BUSINESS.DTOs.Teacher;
using App.BUSINESS.Services.Implementations;
using App.BUSINESS.Services.Interfaces;
using App.DAL.Context;
using App.DAL.Repositories.Implementations;
using App.DAL.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CrackUdemy.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();




            builder.Services.AddTransient<IValidator<CreateCategoryDto>, CategoryCreateDtoValidator>();
            builder.Services.AddTransient<IValidator<UpdateCategoryDto>, CategoryUpdateDtoValidator>();
            builder.Services.AddTransient<IValidator<CreateStudentDto>, StudentCreateDtoValidator>();
            builder.Services.AddTransient<IValidator<UpdateStudentDto>, StudentUpdateDtoValidator>();
            builder.Services.AddTransient<IValidator<CreateTeacherDto>, TeacherCreateDtoValidator>();
            builder.Services.AddTransient<IValidator<UpdateTeacherDto>, TeacherUpdateDtoValidator>();
            builder.Services.AddTransient<IValidator<CreateCourseDto>, CourseCreateDtoValidator>();
            builder.Services.AddTransient<IValidator<UpdateCourseDto>, CourseUpdateDtoValidator>();



            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}