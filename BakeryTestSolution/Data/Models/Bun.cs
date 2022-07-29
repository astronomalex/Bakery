using System;

namespace BakeryTestSolution.Data.Models
{
    public class Bun
    {
        public int Id { get; set; }
        
        public virtual Category Category { get; set; }

        public DateTime TimeManufacture { get; set; }
    }
}