using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.BLL;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderRequestDto dto)
    {
        if (dto.Items == null || !dto.Items.Any())
            return BadRequest("Замовлення не може бути порожнім");

        var result = await _orderService.CreateOrderAsync(dto);
        return CreatedAtAction(nameof(CreateOrder), result);
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrder(int orderId)
    {
        try
        {
            var result = await _orderService.GetOrderByIdAsync(orderId);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }

    [HttpPatch("{orderId}/status")]
    public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] StatusUpdateRequestDto dto)
    {
        try
        {
            var result = await _orderService.UpdateOrderStatusAsync(orderId, dto);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }
}