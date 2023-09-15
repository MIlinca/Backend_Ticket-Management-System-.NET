using AutoMapper;
using TicketManagementSystem.Models;
using TicketManagementSystem.Models.Dto;
using TicketManagementSystem.Repositories;
using TicketManagementSystem.Repository;

namespace TicketManagementSystem.BusinessLogic
{
    public class OrderServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITicketCategoryRepository _ticketCategoryRepository;
        private readonly IMapper _mapper;
        private readonly TicketManagementDatabaseContext _ticketmanagementDatabaseContext;
        public OrderServices(IOrderRepository orderRepository, IMapper mapper, ICustomerRepository customerRepository, ITicketCategoryRepository ticketCategoryRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _ticketmanagementDatabaseContext = new TicketManagementDatabaseContext();
        }
        public IEnumerable<OrderDto> GetAllOrders()
        {
            var order = _orderRepository.GetAll().AsQueryable();
            return _mapper.ProjectTo<OrderDto>(order);
        }
        public async Task<OrderDto> GetOrderById(int id)
        {
            var order = await _orderRepository.GetById(id);
            if (order == null)
            {
                new Exception("The order does not exist!");
            }
            return _mapper.Map<OrderDto>(@order);

        }
        public async Task<OrderDto> UpdateOrder(OrderPatchDto orderPatch)
        {
            var orderEntity = await _orderRepository.GetById(orderPatch.OrderId);
            if (orderEntity == null)
            {
                new Exception("The order does not exist!");
            }
            TicketCategory ticketCategory = await _ticketCategoryRepository.GetByDescription(orderPatch.TicketCategory, orderPatch.EventId);
            if (ticketCategory == null)
            {
                new Exception("The ticket's category does not exist!");
            }
            orderEntity.TicketCategoryId = ticketCategory.TicketCategoryId;
            _mapper.Map(orderPatch, orderEntity);
            // orderEntity.TicketCategoryId =ticketCategory.TicketCategoryId;
            orderEntity.TotalPrice = orderEntity.TicketCategory.Price * orderPatch.NumberOfTickets;
            _orderRepository.Update(orderEntity);
            return _mapper.Map<OrderDto>(orderEntity);
        }
        public async Task<bool> Delete(int id)
        {
            var orderEntity = await _orderRepository.GetById(id);
            if (orderEntity == null)
            {
                new Exception("The order does not exist!");
            }
            _orderRepository.Delete(orderEntity);
            return true;
        }
        public async Task<Order> AddOrder(OrderDto orderDto)
        {
            Customer customer = await _customerRepository.GetByName(orderDto.CustomerName);
            if (customer == null)
            {
                new Exception("The customer does not exist!");

            }
            TicketCategory ticketCategory = await _ticketCategoryRepository.GetByDescription(orderDto.TicketCategory,orderDto.EventId);
            if (ticketCategory == null)
            {
                new Exception("The ticket's category does not exist!");
            }

            Order newOrder = new Order();
            _mapper.Map(orderDto, newOrder);

            newOrder.CustomerId = customer.CustomerId;
            newOrder.TicketCategoryId = ticketCategory.TicketCategoryId;
            newOrder.TotalPrice = ticketCategory.Price * orderDto.NumberOfTickets;
            _orderRepository.Add(newOrder);
            await _ticketmanagementDatabaseContext.SaveChangesAsync();
            return newOrder;
        }
    }
}