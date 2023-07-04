using AutoMapper;
using Fiorello.Core.Entities;
using Fiorello.Core.Repositories;
using Fiorello.Services.Dtos.CategoryDtos;
using FiorelloServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("")]
        public IActionResult Create(CategoryPostDto categoryPostDto)
        {
            var result = _categoryService.Create(categoryPostDto);
            return StatusCode(201, result);

        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, CategoryPutDto categoryPutDto)
        {
            _categoryService.Edit(id, categoryPutDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryGetDto> Get(int id) 
        { 
            return Ok(_categoryService.GetById(id));   
        }

        /*[HttpGet("{id}")]

        public ActionResult<CategoryGetDto> Get(int id)
         {
             Category entity = _categoryRepository.Get(x => x.Id == id);
             if (entity == null)
             {
                 return NotFound();
             }
             var data = _mapper.Map<CategoryGetDto>(entity);

             return Ok(data);
         }
*/
       
    }
}
