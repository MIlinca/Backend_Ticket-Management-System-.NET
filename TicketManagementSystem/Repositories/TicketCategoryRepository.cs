using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly TicketManagementDatabaseContext _ticketmanagementDatabaseContext;
        public TicketCategoryRepository()
        {
            _ticketmanagementDatabaseContext = new TicketManagementDatabaseContext();
        }
        public async Task<TicketCategory> GetByDescription(string description,int eventId)
        {
            var ticketcat = await _ticketmanagementDatabaseContext.TicketCategories.Where(t => t.Description == description && t.EventId == eventId).FirstOrDefaultAsync();
            return ticketcat;
        }
    }
}