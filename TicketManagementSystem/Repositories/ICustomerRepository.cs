using TicketManagementSystem.Models;
using TicketManagementSystem.Models.Dto;

namespace TicketManagementSystem.Repository
{
    public interface ICustomerRepository
    {
        
        Task<Customer> GetByName(string name);
    }
}
