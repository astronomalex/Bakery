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
    private readonly IPriceRepository _priceRepository;
    private readonly ICategoryRepository _categoryRepository;

    public BunController(
        IBunRepository bunRepository,
        IPriceRepository priceRepository,
        ICategoryRepository categoryRepository)
    {
        _bunRepository = bunRepository;
        _priceRepository = priceRepository;
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
                Name = bun.Category.Name,
                Price = _priceRepository.getPrice(bun),
                ActualPrice = _priceRepository.getActualPrice(bun),
                NextPrice = _priceRepository.getNextPrice(bun),
                TimeManufacture = bun.TimeManufacture,
                TimeNextChangePrice = _priceRepository.getNextChangePrice(bun)
            };
            dtos.Add(dto);
        }

        return Ok(dtos);
    }

    [HttpPost("addlist")]
    public IActionResult AddList(int quantity, int categoryId)
    {
        _bunRepository.AddList(quantity, categoryId);
        return Ok(quantity);
    }

    [HttpPost("add")]
    public IActionResult Add(CreateBunDto createBunDto)
    {
        _bunRepository.Add(createBunDto);
        return Ok(createBunDto);
    }
}