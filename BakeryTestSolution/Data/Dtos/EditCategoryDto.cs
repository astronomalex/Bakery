namespace BakeryTestSolution.Data.Dtos
{
    public class EditCategoryDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int controlPeriodHours { get; set; }
        public int  expirationDateHours { get; set; }
    }
}