using System;
using System.Collections;
using System.Collections.Generic;
using BakeryTestSolution.Data.Dtos;
using BakeryTestSolution.Data.Models;

namespace BakeryTestSolution.Data.Interfaces
{
    public interface IBunRepository
    {
        IEnumerable<Bun> GetAll();
        int AddList(AddBunsDto dto);
        bool Remove(int id);
    }
}