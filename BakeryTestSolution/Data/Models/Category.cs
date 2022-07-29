using System.Collections.Generic;

namespace BakeryTestSolution.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Bun> Buns { get; set; }
    }
}