using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Metadata;
using TicketManagementSystem.Models;
using static NLog.LayoutRenderers.Wrappers.ReplaceLayoutRendererWrapper;

namespace TicketManagementSystem.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly TicketManagementDatabaseContext _ticketmanagementDatabaseContext;
        public EventRepository()
        {
            _ticketmanagementDatabaseContext = new TicketManagementDatabaseContext();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _ticketmanagementDatabaseContext.Events;
            return events;
        }

        public async Task<Event> GetById(int id)
        {
            var @event = await _ticketmanagementDatabaseContext.Events
                .Include(e => e.Venue)
                .Include(e => e.EventType)
                .FirstOrDefaultAsync(e => e.EventId == id);
            return @event;
        }

        public async Task Update(Event @event)
        {
            _ticketmanagementDatabaseContext.Entry(@event).State = EntityState.Modified;
            await _ticketmanagementDatabaseContext.SaveChangesAsync();
        }

        public void Delete(Event @event)
        {
            _ticketmanagementDatabaseContext.Remove(@event);
            _ticketmanagementDatabaseContext.SaveChanges();
        }

        public void Add(Event @event)
        {
            _ticketmanagementDatabaseContext.Add(@event);
            _ticketmanagementDatabaseContext.SaveChanges();
        }
        public  IEnumerable<Event> GetByVenue(int venueID)
        {
            var events = _ticketmanagementDatabaseContext.Events
                .Include(e => e.Venue)
                .Include(e => e.EventType)
                .Include(e => e.TicketCategories)
                .Where(e => e.VenueId == venueID)
                ;
            return events;
        }
        public IEnumerable<Event> GetByType(int eventTypeId)
        {
            var events =  _ticketmanagementDatabaseContext.Events
                .Include(e => e.Venue)
                .Include(e => e.EventType)
                .Where(e => e.EventTypeId == eventTypeId)
                ;
            return events;
        }
    }
}
