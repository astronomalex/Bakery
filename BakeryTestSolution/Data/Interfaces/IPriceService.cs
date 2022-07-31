using System;
using BakeryTestSolution.Data.Models;

namespace BakeryTestSolution.Data.Interfaces
{
    public interface IPriceService
    {
        public decimal getActualPrice(Bun bun);
        public decimal getNextPrice(Bun bun);
        public DateTime getNextChangePrice(Bun bun);
    }
}