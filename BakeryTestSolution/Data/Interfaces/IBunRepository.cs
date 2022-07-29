using System.Collections;
using System.Collections.Generic;
using BakeryTestSolution.Data.Dtos;
using BakeryTestSolution.Data.Models;

namespace BakeryTestSolution.Data.Interfaces
{
    public interface IBunRepository
    {
        IEnumerable<Bun> GetAll();
        Bun Add(CreateBunDto createBunDto);
        int AddList(int quantity, int categoryId);
        int SetExpirationDate(int hours);
    }
}