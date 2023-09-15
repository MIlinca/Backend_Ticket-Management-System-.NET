namespace TicketManagementSystem.Models.Dto
{
    public class OrderPatchDto
    {
        public int OrderId { get; set; }

        public string TicketCategory { get; set; }

        public long NumberOfTickets { get; set; }
        public int  EventId { get; set; }
      
    }
}
