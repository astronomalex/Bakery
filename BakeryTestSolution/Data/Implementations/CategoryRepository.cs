using System.Collections.Generic;
using System.Linq;
using BakeryTestSolution.Data.Interfaces;
using BakeryTestSolution.Data.Models;

namespace BakeryTestSolution.Data.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        IList<Category> categories = new List<Category>();

        public CategoryRepository()
        {
            this.categories.Add(new Category {Id = 1, Name = "Круасан"});
            this.categories.Add(new Category {Id = 2, Name = "Багет"});
            this.categories.Add(new Category {Id = 3, Name = "Батон"});
            this.categories.Add(new Category {Id = 4, Name = "Крендель"});
            this.categories.Add(new Category {Id = 5, Name = "Сметанник"});
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

        public int Add(string categoryName)
        {
            var newId = (from c in categories
                select c.Id).Max() + 1;
            categories.Add(new Category{Id = newId, Name = categoryName});
            return newId;
        }

        public int Remove(int id)
        {
            var category = categories.First(c => c.Id == id);
            categories.Remove(category);
            return id;
        }

        public int SetExpirationDate(int hours)
        {
            throw new System.NotImplementedException();
        }
    }
}