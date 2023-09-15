namespace TicketManagementSystem.Models.Dto
{
    public class EventDto
    {
        public int EventId { get; set; }

        public string? Venue { get; set; }

        public string? EventType { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
      

        public List<TicketCategory> ticketCategories { get; set; }
    }
}
