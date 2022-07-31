using System.Collections.Generic;
using BakeryTestSolution.Data.Dtos;
using BakeryTestSolution.Data.Models;

namespace BakeryTestSolution.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetCategory(int id);
         int Add(CreateCategoryDto dto);
        int Remove(int id);
        Category Update(EditCategoryDto dto);
    }
}