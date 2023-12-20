using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Shopping.CORE.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
        public decimal? TotalAmount { get; set; }
    }

    public class OrderListDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
        public decimal? TotalAmount { get; set; }
    }

    public class OrderDetailedDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
        public decimal? TotalAmount { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }

    public class OrderInsertDTO
    {
        public DateTime? CreatedAt { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
        public decimal? TotalAmount { get; set; }
    }

    public class OrderUpdateDTO
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public decimal? TotalAmount { get; set; }
    }

    public class OrderDetailDTO
    {
        public int Id { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public DateTime? CreatedAt { get; set; }

        public ProductCategoryDTO Product { get; set; }
    }

    public class OrderDetailInsertDTO
    {
        public int? OrdersId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }

    public class OrderDetailUpdateDTO
    {
        public int Id { get; set; }
        public int? OrdersId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}