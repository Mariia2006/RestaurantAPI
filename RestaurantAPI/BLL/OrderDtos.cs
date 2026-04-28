using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.BLL;

public class OrderRequestDto
{
    [Required(ErrorMessage = "Ім'я замовника обов'язкове")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Телефон обов'язковий")]
    [Phone(ErrorMessage = "Некоректний формат телефону")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Адреса доставки обов'язкова")]
    public string DeliveryAddress { get; set; } = string.Empty;

    [Required(ErrorMessage = "Замовлення не може бути порожнім")]
    [MinLength(1, ErrorMessage = "Додайте хоча б одну страву")]
    public List<OrderItemRequestDto> Items { get; set; } = new();
}

public class OrderItemRequestDto
{
    [Required(ErrorMessage = "ID страви обов'язковий")]
    public int DishId { get; set; }

    [Range(1, 50, ErrorMessage = "Кількість порцій має бути від 1 до 50")]
    public int Quantity { get; set; }
}

public class OrderResponseDto
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
}

public class StatusUpdateRequestDto
{
    [Required(ErrorMessage = "Новий статус обов'язковий")]
    [RegularExpression("^(in_progress|ready|delivering|completed)$",
        ErrorMessage = "Статус може бути лише: in_progress, ready, delivering, або completed")]
    public string NewStatus { get; set; } = string.Empty;
}

public class StatusUpdateResponseDto
{
    public int OrderId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}