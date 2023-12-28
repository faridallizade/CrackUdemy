using App.BUSINESS.DTOs.Brand;
using App.BUSINESS.DTOs.Category;
using App.BUSINESS.DTOs.Student;
using App.BUSINESS.Services.Interfaces;
using App.CORE.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly IValidator<CreateStudentDto> _validator;
        private readonly IValidator<UpdateStudentDto> _validatorUpdate;


        public StudentController(IStudentService service, IValidator<CreateStudentDto> validator, IValidator<UpdateStudentDto> validatorUpdate)
        {
            _service = service;
            _validator = validator;
            _validatorUpdate = validatorUpdate;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var students = await _service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Student student = await _service.GetById(id);
            return StatusCode(StatusCodes.Status200OK, student);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateStudentDto createStudentDto)
        {
            var validationResult = _validator.Validate(createStudentDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _service.Create(createStudentDto);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateStudentDto updateStudentDto)
        {
            var validationResult = _validatorUpdate.Validate(updateStudentDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _service.Update(updateStudentDto);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete("id")]

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status200OK);

        }

    }
}
