using Cibertec.Shopping.CORE.DTOs;
using Cibertec.Shopping.CORE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ordersDetailed = await _orderService.GetAll();
            if(ordersDetailed == null)
                return NotFound();

            return Ok(ordersDetailed);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetById(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] OrderInsertDTO orderInsertDTO)
        {
            var result = await _orderService.Insert(orderInsertDTO);
            if(!result)
                return BadRequest();
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] OrderUpdateDTO orderUpdateDTO)
        {
            if (id != orderUpdateDTO.Id)
                return BadRequest();

            var result = await _orderService.Update(orderUpdateDTO);
            if(!result)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            var result = await _orderService.Delete(id);
            if(!result)
                return BadRequest();

            return Ok(result);
        }

        //Insert order detail
        [HttpPost("orderdetail")]
        public async Task<IActionResult> InsertOrderDetail([FromBody] OrderDetailInsertDTO orderDetailInsertDTO)
        {
            var result = await _orderService.InsertOrderDetail(orderDetailInsertDTO);
            if(!result)
                return BadRequest();

            return Ok(result);
        }

        //Update order detail
        [HttpPut("orderdetail/{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, [FromBody] OrderDetailUpdateDTO orderDetailUpdateDTO)
        {
            if (id != orderDetailUpdateDTO.Id)
                return BadRequest();

            var result = await _orderService.UpdateOrderDetail(orderDetailUpdateDTO);
            if(!result)
                return BadRequest();

            return Ok(result);
        }

        //Delete order detail
        [HttpDelete("orderdetail/{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var result = await _orderService.DeleteOrderDetail(id);
            if(!result)
                return BadRequest();

            return Ok(result);
        }
    }
}
