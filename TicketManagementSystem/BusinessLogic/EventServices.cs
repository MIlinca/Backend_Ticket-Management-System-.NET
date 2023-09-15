using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.Models;
using TicketManagementSystem.Models.Dto;
using TicketManagementSystem.Repositories;

namespace TicketManagementSystem.BusinessLogic
{
    public class EventServices
           {
            private readonly IEventRepository _eventRepository;
            private readonly IMapper _mapper;
            private readonly IVenueRepository _venueRepository;
            private readonly IEventTypeRepository _eventTypeRepository;
        private readonly TicketManagementDatabaseContext _ticketmanagementDatabaseContext;

            public EventServices(IEventRepository eventRepository, IMapper mapper, IVenueRepository venueRepository, IEventTypeRepository eventTypeRepository)
            {
                _eventRepository = eventRepository;
                _mapper = mapper;
                _venueRepository = venueRepository;
                _eventTypeRepository = eventTypeRepository;
            _ticketmanagementDatabaseContext = new TicketManagementDatabaseContext();
        }


            public IEnumerable<EventDto> GetAll()
            {
                var events = _eventRepository.GetAll().AsQueryable();
            return _mapper.ProjectTo<EventDto>(events); 
            }

            public async Task<EventDto> GetEventById(int id)
            {
                var @event =  await _eventRepository.GetById(id);
                if (@event == null)
                {
                throw new Exception("The event does not exist!");
            }
                return _mapper.Map<EventDto>(@event);
            }
            public async Task<EventDto> UpdateEvent(EventPatchDto eventPatchDto)
            {
                var eventEntity =await _eventRepository.GetById(eventPatchDto.EventId);
                if (eventEntity == null)
                {
                new Exception("The event does not exist!");
            }
            Venue venue = await _venueRepository.GetByName(eventPatchDto.Venue);
            if (venue == null)
            {
                throw new Exception("The location does not exist!");
            }

            EventType eventType = await _eventTypeRepository.GetByName(eventPatchDto.EventType);
            if (eventType == null)
            {
                throw new Exception("The event type does not exist!");
            }
            eventEntity.VenueId=venue.VenueId; 
            eventEntity.EventTypeId=eventType.EventTypeId;
            _mapper.Map(eventPatchDto, eventEntity);

            await _eventRepository.Update(eventEntity);
            return _mapper.Map<EventDto>(eventEntity);
            }
            public async Task<bool> DeleteEvent(int id)
            {
                var eventEntity = await _eventRepository.GetById(id);
                if (eventEntity == null)
                {
               throw new Exception("The event does not exist!");
                }
                _eventRepository.Delete(eventEntity);
                return true;
                
            }
            public async Task<EventDto> AddEvent(EventDto eventAdd)
            {
                Venue venue = await _venueRepository.GetByName(eventAdd.Venue);
                if (venue == null)
                {
                    throw new Exception("The location does not exist!");
                }

                EventType eventType = await _eventTypeRepository.GetByName(eventAdd.EventType);
                if (eventType == null)
                {
                    throw new Exception("The event type does not exist!");
                }

                Event newEvent = new Event();
                _mapper.Map(eventAdd, newEvent);
                newEvent.VenueId = venue.VenueId;
                newEvent.EventTypeId = eventType.EventTypeId;

                 _eventRepository.Add(newEvent);
            await _ticketmanagementDatabaseContext.SaveChangesAsync();
            var newEventAdd = _mapper.Map<EventDto>(newEvent);
            newEventAdd.EventType = eventType.EventTypeName;
            newEventAdd.Venue = venue.Location;
            return newEventAdd;
            }
        public IEnumerable<EventDto> GetByVenue(string venueName)
        {
            var venue= _venueRepository.GetByName(venueName);
            if (venue == null)
            {
                throw new Exception("The venue type does not exist!");
            }
            var events = _eventRepository.GetByVenue(venue.Result.VenueId).AsQueryable();
            if (events == null)
            {
                throw new Exception("No events found for the given venue.");
            }

            return _mapper.ProjectTo<EventDto>(events); 
        }
        public  IEnumerable<EventDto> GetByType(string type)
        {
            var eventType = _eventTypeRepository.GetByName(type);
            if (eventType == null)
            {
                throw new Exception("The event type does not exist!");
            }

            var events = _eventRepository.GetByType(eventType.Result.EventTypeId).AsQueryable();
            if (events == null)
            {
                throw new Exception("No events found for the given event type.");
            }

            return _mapper.ProjectTo<EventDto>(events);
        }

    }
    }
