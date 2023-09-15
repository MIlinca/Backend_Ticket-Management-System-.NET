namespace TicketManagementSystem.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public string CustomerName { get; set; }

        public string TicketCategory { get; set; }

        public DateTime? OrderedAt { get; set; }

        public int NumberOfTickets { get; set; }

        public decimal? TotalPrice { get; set; }
        public int EventId { get; set; }
    }
}
