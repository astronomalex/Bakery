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
        private readonly IPriceRepository _priceRepository;
        private readonly ICategoryRepository _categoryRepository;
        private IList<Bun> buns = new List<Bun>();  

        public BunMockRepository(IPriceRepository priceRepository, ICategoryRepository categoryRepository)
        {
            _priceRepository = priceRepository;
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Bun> GetAll() => buns;


        public Bun Add(CreateBunDto createBunDto)
        {
            var category = _categoryRepository.GetCategory(createBunDto.CategoryId);
            var bun = new Bun
            {
                Category = category,
                TimeManufacture = createBunDto.TimeManufacture
            };
            buns.Add(bun);
            return bun;
        }

        public int AddList(int quantity, int categoryId)
        {
            var now = DateTime.Now;
            var category = _categoryRepository.GetAll().FirstOrDefault(c => c.Id == categoryId);
            for (var i = 1; i <= quantity; i++)
                buns.Add(
                    new Bun
                    {
                        TimeManufacture = now,
                        Category = category
                    });

            return buns.Count;
        }

        public int SetExpirationDate(int hours)
        {
            Croissant.ControlPeriod = TimeSpan.FromHours(hours);
            return hours;
        }
    }
}