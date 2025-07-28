namespace DineDelicious.Models.DTOs
{
    public class BillDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime GeneratedAt { get; set; }
        public string PaymentMethod { get; set; }
    }
}
