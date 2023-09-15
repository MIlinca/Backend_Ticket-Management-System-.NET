 using Microsoft.AspNetCore.Mvc;
using TicketManagementSystem.BusinessLogic;
using TicketManagementSystem.Models.Dto;


namespace TicketManagementSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventServices _eventService;

        public EventController(EventServices eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetAll()
        {
            var events =_eventService.GetAll();
            return Ok(events);
        }
        [HttpGet]
        public async Task<ActionResult<EventDto>> GetById(int id)
        {
            var eventId =await _eventService.GetEventById(id);
            return Ok(eventId);
        }
     
        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetByVenue(string venueName)
        {
            var events = _eventService.GetByVenue(venueName);
            return Ok(events);
        }
        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetByType(string type)
        {
            var events = _eventService.GetByType(type);
            return Ok(events);
        }
        [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> EntityUpdate(EventPatchDto eventPatch)
        {
            var eventEntity = await _eventService.UpdateEvent(eventPatch);
            return Ok(eventEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {

            return Ok(await _eventService.DeleteEvent(id));
        }

        [HttpPost]
        public async Task<ActionResult<EventDto>> AddEvent(EventDto eventAdd)
        {
                var newEvent = await _eventService.AddEvent(eventAdd);
                return newEvent;
        }
    }
}
