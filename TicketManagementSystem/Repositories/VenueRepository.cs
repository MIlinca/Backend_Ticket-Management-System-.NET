using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public class VenueRepository: IVenueRepository
    {
        private readonly TicketManagementDatabaseContext _ticketmanagementDatabaseContext;

        public VenueRepository()
        {
            _ticketmanagementDatabaseContext = new TicketManagementDatabaseContext();         
        }

       public async Task<Venue> GetByName(string name)
        {
          var venue= await _ticketmanagementDatabaseContext.Venues.FirstOrDefaultAsync(v=>v.Location==name);
            return venue;
        }
    }
}
