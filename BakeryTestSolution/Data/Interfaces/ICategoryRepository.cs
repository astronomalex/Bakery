using System.Collections.Generic;
using BakeryTestSolution.Data.Models;

namespace BakeryTestSolution.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetCategory(int id);
         int Add(string categoryName);
        int Remove(int id);
        int SetExpirationDate(int hours);
    }
}