using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Models;
using TicketManagementSystem.Models.Dto;
using TicketManagementSystem.Repository;

namespace TicketManagementSystem.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly TicketManagementDatabaseContext _ticketmanagementDatabaseContext;

        public CustomerRepository()
        {
            _ticketmanagementDatabaseContext = new TicketManagementDatabaseContext();
        }
        public async Task<Customer> GetByName(string name)
        {
            var customer= await _ticketmanagementDatabaseContext.Customers.Where(c => c.CustomerName==name).FirstOrDefaultAsync();
            return customer;
        }
    }
}
