namespace RestaurantAPI.DAL;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string DeliveryAddress { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Created";

    // Список страв у цьому замовленні
    public List<OrderItem> Items { get; set; } = new();
}

public class OrderItem
{
    public int Id { get; set; }
    public int DishId { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtTimeOfOrder { get; set; } // Фіксуємо ціну на момент покупки
}