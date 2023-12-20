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
    }
}