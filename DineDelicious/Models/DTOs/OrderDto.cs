namespace DineDelicious.Models.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
