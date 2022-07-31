using System;
using System.Collections.Generic;
using System.Linq;
using BakeryTestSolution.Data.Dtos;
using BakeryTestSolution.Data.Interfaces;
using BakeryTestSolution.Data.Models;

namespace BakeryTestSolution.Data.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        IList<Category> categories = new List<Category>();

        public CategoryRepository()
        {
            this.categories.Add(new Category
            {
                Id = 1, Name = "Круасан", Price = 95, ControlPeriodHours = TimeSpan.FromHours(24),
                ExpirationDateHours = TimeSpan.FromHours(72)
            });
            this.categories.Add(new Category
            {
                Id = 2, Name = "Багет", Price = 100, ControlPeriodHours = TimeSpan.FromHours(24),
                ExpirationDateHours = TimeSpan.FromHours(72)
            });
            this.categories.Add(new Category
            {
                Id = 3, Name = "Батон", Price = 90, ControlPeriodHours = TimeSpan.FromHours(24),
                ExpirationDateHours = TimeSpan.FromHours(72)
            });
            this.categories.Add(new Category
            {
                Id = 4, Name = "Крендель", Price = 85, ControlPeriodHours = TimeSpan.FromHours(24),
                ExpirationDateHours = TimeSpan.FromHours(72)
            });
            this.categories.Add(new Category
            {
                Id = 5, Name = "Сметанник", Price = 57, ControlPeriodHours = TimeSpan.FromHours(24),
                ExpirationDateHours = TimeSpan.FromHours(72)
            });
        }

        public IEnumerable<Category> GetAll()
        {
            return categories;
        }

        public Category GetCategory(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public int Add(CreateCategoryDto dto)
        {
            var newId = (from c in categories
                select c.Id).Max() + 1;
            categories.Add(new Category
            {
                Id = newId,
                Name = dto.Name,
                ControlPeriodHours = TimeSpan.FromHours(dto.ControlPeriod),
                ExpirationDateHours = TimeSpan.FromHours(dto.ExpirationDateHours)
            });
            return newId;
        }

        public int Remove(int id)
        {
            var category = categories.First(c => c.Id == id);
            categories.Remove(category);
            return id;
        }

        public Category Update(EditCategoryDto dto)
        {
            var newCategory = categories.FirstOrDefault(c => c.Id == dto.id);
            if (newCategory == null) throw new NullReferenceException();
            if (dto.controlPeriodHours > dto.expirationDateHours)
                throw new Exception("Срок годности не может быть меньше контрольного периода");
            newCategory.ControlPeriodHours = TimeSpan.FromHours(dto.controlPeriodHours);
            newCategory.ExpirationDateHours = TimeSpan.FromHours(dto.expirationDateHours);
            if (dto.price <= 0)
                throw new Exception("Цена не может быть 0 или меньше");
            newCategory.Price = dto.price;
            return newCategory;
        }
    }
}