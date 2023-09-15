using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public interface IEventTypeRepository
    {
        Task<EventType> GetByName(string name);
    }
}
