using Cibertec.Shopping.CORE.DTOs;

namespace Cibertec.Shopping.CORE.Interfaces
{
    public interface IOrderService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<OrderDetailedDTO>> GetAll();
        Task<OrderDetailedDTO> GetById(int id);
        Task<bool> Insert(OrderInsertDTO orderInsertDTO);
        Task<bool> Update(OrderUpdateDTO orderUpdateDTO);
    }
}