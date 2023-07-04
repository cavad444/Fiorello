using AutoMapper;
using Fiorello.Core.Entities;
using Fiorello.Core.Repositories;
using Fiorello.Services.Dtos.FlowerDtos;
using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Api.Controllers
{
  //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private readonly IFlowerService _flowerService;
        public FlowersController(IFlowerService flowerService)
        {
            _flowerService = flowerService;
        }

        [HttpPost("")]
        public IActionResult Create([FromForm] FlowerPostDto flowerPostDto)
        {

            return StatusCode(201, _flowerService.Create(flowerPostDto));
        }


        [HttpGet("all")]
        public ActionResult<List<FlowerGetAllItemDto>> GetAll()
        {
            return Ok(_flowerService.GetAll());
        }

        [HttpPut("{id}")]


        public IActionResult Update(int id, [FromForm]FlowerPutDto flowerPutDto)
        {
            _flowerService.Edit(id, flowerPutDto);
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<FlowerGetDto> Get(int id)
        {
            return Ok(_flowerService.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _flowerService.Delete(id);
            return NoContent();
        }
    }
}
