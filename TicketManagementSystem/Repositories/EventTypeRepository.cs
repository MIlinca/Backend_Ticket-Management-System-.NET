using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public class EventTypeRepository: IEventTypeRepository
    {
        private readonly TicketManagementDatabaseContext _ticketmanagementDatabaseContext;

        public EventTypeRepository()
        {
            _ticketmanagementDatabaseContext = new TicketManagementDatabaseContext();
        }

        public async Task<EventType> GetByName(string name)
        {
            var eventType = await _ticketmanagementDatabaseContext.EventTypes.Where(e => e.EventTypeName==name).FirstOrDefaultAsync();
            return eventType;
        }
    }
    
}
