using System.Collections.Generic;
using System.Linq;
using BakeryTestSolution.Data.Dtos;
using BakeryTestSolution.Data.Interfaces;
using BakeryTestSolution.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IBunRepository _bunRepository;
    private readonly IPriceRepository _priceRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(IBunRepository bunRepository,
        IPriceRepository priceRepository,
        ICategoryRepository categoryRepository)
    {
        _bunRepository = bunRepository;
        _priceRepository = priceRepository;
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> Get()
    {
        var all = _categoryRepository.GetAll();
        return Ok(all);
    }

    [HttpPost("add")]
    public IActionResult Add(string name)
    {
        _categoryRepository.Add(name);
        return Ok($"added {name}");
    }
}