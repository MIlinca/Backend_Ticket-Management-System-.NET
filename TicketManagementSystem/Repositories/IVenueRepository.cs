using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public interface IVenueRepository
    {
        Task<Venue> GetByName(string name);
    }
}
