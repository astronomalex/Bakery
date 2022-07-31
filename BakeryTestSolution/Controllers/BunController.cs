using System;
using System.Collections.Generic;
using System.Linq;
using BakeryTestSolution.Data.Dtos;
using BakeryTestSolution.Data.Interfaces;
using BakeryTestSolution.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("[controller]")]
public class BunController : ControllerBase
{
    private readonly IBunRepository _bunRepository;
    private readonly IPriceService _priceService;
    private readonly ICategoryRepository _categoryRepository;

    public BunController(
        IBunRepository bunRepository,
        IPriceService priceService,
        ICategoryRepository categoryRepository)
    {
        _bunRepository = bunRepository;
        _priceService = priceService;
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BunDto>> Get()
    {
        var all = _bunRepository.GetAll();
        var dtos = new List<BunDto>();
        if (all.Count() == 0) return dtos;

        foreach (var bun in all)
        {
            var dto = new BunDto
            {
                Id = bun.Id,
                Name = bun.Category.Name,
                Price = bun.Category.Price,
                ActualPrice = _priceService.getActualPrice(bun),
                NextPrice = _priceService.getNextPrice(bun),
                TimeManufacture = bun.TimeManufacture,
                TimeNextChangePrice = _priceService.getNextChangePrice(bun)
            };
            dtos.Add(dto);
        }

        return Ok(dtos);
    }

    [HttpPost("addlist")]
    public IActionResult AddList([FromBody] AddBunsDto dto)
    {
        _bunRepository.AddList(dto);
        return Ok(dto.quantity);
    }

    [HttpPost("remove")]
    public IActionResult Remove([FromBody] int id)
    {
        return Ok(_bunRepository.Remove(id));
    }
}