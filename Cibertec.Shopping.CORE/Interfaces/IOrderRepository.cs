using Cibertec.Shopping.CORE.Entities;

namespace Cibertec.Shopping.CORE.Interfaces
{
    public interface IOrderRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Orders>> GetAll();
        Task<Orders> GetById(int id);
        Task<bool> Insert(Orders order);
        Task<bool> Update(Orders order);
        Task<bool> InsertOrderDetail(OrderDetail orderDetail);
        Task<bool> UpdateOrderDetail(OrderDetail orderDetail);
        Task<OrderDetail> GetOrderDetailById(int id);
        Task<bool> DeleteOrderDetail(int id);
    }
}