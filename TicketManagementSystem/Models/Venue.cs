using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace TicketManagementSystem.Models;

public partial class Venue
{
  
    public int VenueId { get; set; }

    public string? Location { get; set; }

    public string? Type { get; set; }

    public long? Capacity { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
