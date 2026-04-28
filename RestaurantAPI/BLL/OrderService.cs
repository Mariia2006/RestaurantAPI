using Microsoft.EntityFrameworkCore;
using RestaurantAPI.DAL;

namespace RestaurantAPI.BLL;

public class OrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<OrderResponseDto> CreateOrderAsync(OrderRequestDto dto)
    {
        var order = new Order
        {
            CustomerName = dto.CustomerName,
            Phone = dto.Phone,
            DeliveryAddress = dto.DeliveryAddress,
            Status = "created"
        };

        decimal total = 0;

        foreach (var itemDto in dto.Items)
        {
            var dish = await _context.Dishes.FindAsync(itemDto.DishId);

            if (dish == null) continue;

            var orderItem = new OrderItem
            {
                DishId = dish.Id,
                Quantity = itemDto.Quantity,
                PriceAtTimeOfOrder = dish.Price
            };

            total += dish.Price * itemDto.Quantity;
            order.Items.Add(orderItem);
        }

        order.TotalAmount = total;

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return new OrderResponseDto
        {
            Id = order.Id,
            Status = order.Status,
            TotalAmount = order.TotalAmount
        };
    }

    // Метод для отримання замовлення
    public async Task<OrderResponseDto> GetOrderByIdAsync(int orderId)
    {
        var order = await _context.Orders.FindAsync(orderId);

        if (order == null)
        {
            throw new KeyNotFoundException($"Замовлення з ID {orderId} не знайдено.");
        }

        return new OrderResponseDto
        {
            Id = order.Id,
            Status = order.Status,
            TotalAmount = order.TotalAmount
        };
    }

    // Метод для зміни статусу персоналом
    public async Task<StatusUpdateResponseDto> UpdateOrderStatusAsync(int orderId, StatusUpdateRequestDto dto)
    {
        var order = await _context.Orders.FindAsync(orderId);

        if (order == null)
        {
            throw new KeyNotFoundException($"Замовлення з ID {orderId} не знайдено.");
        }

        order.Status = dto.NewStatus;
        await _context.SaveChangesAsync();

        return new StatusUpdateResponseDto
        {
            OrderId = order.Id,
            Status = order.Status,
            Message = "Статус замовлення успішно змінено."
        };
    }
}