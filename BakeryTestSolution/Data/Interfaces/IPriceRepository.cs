using System;
using BakeryTestSolution.Data.Models;

namespace BakeryTestSolution.Data.Interfaces
{
    public interface IPriceRepository
    {
        public decimal getPrice(Bun bun);
        public decimal getActualPrice(Bun bun);
        public decimal getNextPrice(Bun bun);
        public DateTime getNextChangePrice(Bun bun);
    }
}