using System;
using System.Collections.Generic;
using System.Linq;
using BakeryTestSolution.Data.Dtos;
using BakeryTestSolution.Data.Interfaces;
using BakeryTestSolution.Data.Models;

namespace BakeryTestSolution.Data.Implementations
{
    public class BunMockRepository : IBunRepository
    {
        private readonly IPriceService _priceService;
        private readonly ICategoryRepository _categoryRepository;
        private IList<Bun> buns = new List<Bun>();  

        public BunMockRepository(IPriceService priceService, ICategoryRepository categoryRepository)
        {
            _priceService = priceService;
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Bun> GetAll() => buns;

        public int AddList(AddBunsDto dto)
        {
            var dateTime = string.IsNullOrEmpty(dto.dateManufacture)? DateTime.Now : Convert.ToDateTime(dto.dateManufacture);
            var category = _categoryRepository.GetAll().FirstOrDefault(c => c.Id == dto.categoryId);
            for (var i = 1; i <= dto.quantity; i++)
                buns.Add(
                    new Bun
                    {
                        Id = getNewId(),
                        TimeManufacture = dateTime,
                        Category = category
                    });

            return buns.Count;
        }

        public bool Remove(int id)
        {
            var bun = buns.FirstOrDefault(b => b.Id == id);
            return bun is not null && buns.Remove(bun);
        }

        private int getNewId()
        {
            return buns.Count > 0? (from b in buns
                select b.Id).Max() + 1: 1;
        }
    }
}