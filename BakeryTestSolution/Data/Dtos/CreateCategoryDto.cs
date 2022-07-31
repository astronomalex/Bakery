namespace BakeryTestSolution.Data.Dtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public int ControlPeriod { get; set; }
        public int  ExpirationDateHours { get; set; }
    }
}