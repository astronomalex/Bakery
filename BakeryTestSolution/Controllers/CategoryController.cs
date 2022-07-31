using System;
using System.Collections.Generic;
using BakeryTestSolution.Data.Dtos;
using BakeryTestSolution.Data.Interfaces;
using BakeryTestSolution.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BakeryTestSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EditCategoryDto>> Get()
        {
            var all = _categoryRepository.GetAll();
            ICollection<EditCategoryDto> dtos = new List<EditCategoryDto>();
            foreach (var category in all)
            {
                dtos.Add(new EditCategoryDto
                {
                    id = category.Id,
                    name = category.Name,
                    price = category.Price,
                    controlPeriodHours = Convert.ToInt32(category.ControlPeriodHours.TotalHours),
                    expirationDateHours = Convert.ToInt32(category.ExpirationDateHours.TotalHours)
                });
            }
            return Ok(dtos);
        }

        [HttpPost("add")]
        public IActionResult Add(CreateCategoryDto dto)
        {
            _categoryRepository.Add(dto);
            return Ok($"added {dto.Name}");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody]EditCategoryDto dto)
        {
            var newCategory = _categoryRepository.Update(dto);
            return Ok($"Updated {newCategory}");
        }

    }
}