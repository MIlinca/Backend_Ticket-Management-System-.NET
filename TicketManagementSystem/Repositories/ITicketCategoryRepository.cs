using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public interface ITicketCategoryRepository
    {
        Task<TicketCategory> GetByDescription(string description, int eventId);
    }
}