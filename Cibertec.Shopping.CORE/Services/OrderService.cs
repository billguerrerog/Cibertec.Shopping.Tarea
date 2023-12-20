using Cibertec.Shopping.CORE.DTOs;
using Cibertec.Shopping.CORE.Entities;
using Cibertec.Shopping.CORE.Interfaces;

namespace Cibertec.Shopping.CORE.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderDetailedDTO>> GetAll()
        {
            var orders = await _repository.GetAll();

            var ordersDTO = orders.Select(p => new OrderDetailedDTO
            {
                Id = p.Id,
                CreatedAt = p.CreatedAt,
                UserId = p.UserId,
                Status = p.Status,
                TotalAmount = p.TotalAmount,

                //Convert OrderDetail to OrderDetailDTO only with the fields we need
                OrderDetails = p.OrderDetail.Select(od => new OrderDetailDTO
                {
                    Id = od.Id,
                    Quantity = od.Quantity,
                    Price = od.Price,
                    CreatedAt = od.CreatedAt,
                    Product = new ProductCategoryDTO
                    {
                        Id = od.Product.Id,
                        Description = od.Product.Description,
                        ImageUrl = od.Product.ImageUrl,
                        Stock = od.Product.Stock,
                        Price = od.Product.Price,
                        Discount = od.Product.Discount,
                        Category = new CategoryListDTO
                        {
                            Id = od.Product.Category.Id,
                            Description = od.Product.Category.Description
                        }
                    }
                }).ToList()
            });

            return ordersDTO;
        }

        public async Task<OrderDetailedDTO> GetById(int id)
        {
            var order = await _repository.GetById(id);

            //Convert Order to OrderDetailedDTO only with the fields we need
            var orderDTO = new OrderDetailedDTO
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                UserId = order.UserId,
                Status = order.Status,
                TotalAmount = order.TotalAmount,

                //Convert OrderDetail to OrderDetailDTO only with the fields we need
                OrderDetails = order.OrderDetail.Select(od => new OrderDetailDTO
                {
                    Id = od.Id,
                    Quantity = od.Quantity,
                    Price = od.Price,
                    CreatedAt = od.CreatedAt,
                    Product = new ProductCategoryDTO
                    {
                        Id = od.Product.Id,
                        Description = od.Product.Description,
                        ImageUrl = od.Product.ImageUrl,
                        Stock = od.Product.Stock,
                        Price = od.Product.Price,
                        Discount = od.Product.Discount,
                        Category = new CategoryListDTO
                        {
                            Id = od.Product.Category.Id,
                            Description = od.Product.Category.Description
                        }
                    }
                }).ToList()
            };     
            return orderDTO;
        }

        public async Task<bool> Insert(OrderInsertDTO orderInsertDTO)
        {
            var order = new Orders
            {
                CreatedAt = orderInsertDTO.CreatedAt,
                UserId = orderInsertDTO.UserId,
                Status = orderInsertDTO.Status,
                TotalAmount = orderInsertDTO.TotalAmount
            };

            return await _repository.Insert(order);
        }

        public async Task<bool> Update(OrderUpdateDTO orderUpdateDTO)
        {
            var order = await _repository.GetById(orderUpdateDTO.Id);
            if (order == null)
                return false;

            order.Status = orderUpdateDTO.Status;
            order.TotalAmount = orderUpdateDTO.TotalAmount;

            return await _repository.Update(order);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
