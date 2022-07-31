using System;

namespace BakeryTestSolution.Data.Dtos
{
    public class BunDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal ActualPrice { get; set; }
        public DateTime TimeManufacture { get; set; }
        public DateTime TimeNextChangePrice { get; set; }
        public decimal NextPrice { get; set; }
    }
}