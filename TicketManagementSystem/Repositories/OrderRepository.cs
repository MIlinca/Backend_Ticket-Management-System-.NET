using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly TicketManagementDatabaseContext _ticketmanagementDatabaseContext;
        public OrderRepository()
        {
            _ticketmanagementDatabaseContext = new TicketManagementDatabaseContext();
        }
        public IEnumerable<Order> GetAll()
        {
            var orders = _ticketmanagementDatabaseContext.Orders;
            return orders;
        }
        public async Task<Order> GetById(int id)
        {
            var @order = _ticketmanagementDatabaseContext.Orders
                .Include(e => e.Customer)
                .Include(e => e.TicketCategory)
                .FirstOrDefault(e => e.OrderId == id);
            return @order;
        }

        public async Task Update(Order @order)
        {
            _ticketmanagementDatabaseContext.Entry(@order).State = EntityState.Modified;
            await _ticketmanagementDatabaseContext.SaveChangesAsync();
        }
        public void Delete(Order @order)
        {
            _ticketmanagementDatabaseContext.Remove(@order);
            _ticketmanagementDatabaseContext.SaveChanges();
        }
        public void Add(Order @order)
        {
            _ticketmanagementDatabaseContext.Add(@order);
            _ticketmanagementDatabaseContext.SaveChanges();
        }
    }
}
