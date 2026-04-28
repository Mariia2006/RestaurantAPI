namespace RestaurantAPI.DAL;

public class Booking
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int GuestsCount { get; set; }
    public string Status { get; set; } = "Confirmed";
}