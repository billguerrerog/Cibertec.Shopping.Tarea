using Cibertec.Shopping.CORE.Entities;
using Cibertec.Shopping.CORE.Interfaces;
using Cibertec.Shopping.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Shopping.INFRASTRUCTURE.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDbcibertecContext _context;

        public OrderRepository(StoreDbcibertecContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Orders>> GetAll()
        {
            return await _context.Orders
                .Include(z => z.OrderDetail)
                .ThenInclude(x => x.Product)
                .ThenInclude(y => y.Category)
                .ToListAsync();
        }

        public async Task<Orders> GetById(int id)
        {
            return await _context.Orders
                    .Where(w => w.Id == id)
                    .Include(z => z.OrderDetail)
                    .ThenInclude(x => x.Product)
                    .ThenInclude(y => y.Category)
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Orders order)
        {
            await _context.Orders.AddAsync(order);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Orders order)
        {
            _context.Orders.Update(order);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findOrder = await _context
                            .Orders
                            .Where(x => x.Id == id && x.Status == "A")
                            .FirstOrDefaultAsync();
            if (findOrder == null)
                return false;

            findOrder.Status = "I";
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

    }
}
