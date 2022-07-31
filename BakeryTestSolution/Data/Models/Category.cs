using System;
using System.Collections.Generic;

namespace BakeryTestSolution.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan ControlPeriodHours { get; set; } = TimeSpan.FromHours(48);
        public TimeSpan ExpirationDateHours { get; set; } = TimeSpan.FromHours(96);

        public virtual ICollection<Bun> Buns { get; set; }
    }
}