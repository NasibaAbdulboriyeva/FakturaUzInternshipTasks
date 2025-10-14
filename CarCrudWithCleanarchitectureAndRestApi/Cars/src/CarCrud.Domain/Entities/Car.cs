namespace CarCrud.Domain.Entities
{
    public class Car
    {
        public long CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarNumber { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public long UserId { get; set; }
        public User User { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}


