using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.BLL;

public class BookingRequestDto
{
    [Required(ErrorMessage = "Ім'я обов'язкове")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Телефон обов'язковий")]
    [Phone(ErrorMessage = "Некоректний формат телефону")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Дата обов'язкова")]
    public string Date { get; set; } = string.Empty;

    [Required(ErrorMessage = "Час обов'язковий")]
    public string Time { get; set; } = string.Empty;

    [Range(1, 20, ErrorMessage = "Кількість гостей має бути від 1 до 20")]
    public int GuestsCount { get; set; }
}

public class BookingResponseDto
{
    public int BookingId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}