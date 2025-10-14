namespace CarCrud.Application.Dtos
{
    public class CreateCarDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarNumber { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public long UserId { get; set; }
    }
}
