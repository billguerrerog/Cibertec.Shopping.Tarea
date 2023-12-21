using Cibertec.Shopping.CORE.DTOs;
using Cibertec.Shopping.CORE.Entities;

namespace Cibertec.Shopping.CORE.Interfaces
{
    public interface IOrderService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<OrderDetailedDTO>> GetAll();
        Task<OrderDetailedDTO> GetById(int id);
        Task<bool> Insert(OrderInsertDTO orderInsertDTO);
        Task<bool> Update(OrderUpdateDTO orderUpdateDTO);
        Task<bool> InsertOrderDetail(OrderDetailInsertDTO orderDetailInsertDTO);
        Task<bool> UpdateOrderDetail(OrderDetailUpdateDTO orderDetailUpdateDTO);
        Task<bool> DeleteOrderDetail(int id);
    }
}