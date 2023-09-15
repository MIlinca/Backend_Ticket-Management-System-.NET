namespace TicketManagementSystem.Models.Dto
{
    public class EventPatchDto
    {
        public int EventId { get; set; }

        public string? Name { get; set; }= string.Empty;

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? EventType { get; set; }
        public string? Venue { get; set; }
    }
}
