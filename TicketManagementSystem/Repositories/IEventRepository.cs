using TicketManagementSystem.Models;
using TicketManagementSystem.Models.Dto;

namespace TicketManagementSystem.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Task<Event> GetById(int id);
        Task Update(Event @event);
        void Delete(Event @event);
        void Add(Event @event);
        IEnumerable<Event> GetByVenue(int venueID);
        IEnumerable<Event> GetByType(int eventTypeId);
    }
}