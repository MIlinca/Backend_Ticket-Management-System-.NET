using TicketManagementSystem.Models;

namespace TicketManagementSystem.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Task<Order> GetById(int id);
        Task Update(Order @order);
        void Delete(Order @order);
        void Add(Order @order);
    }
}
