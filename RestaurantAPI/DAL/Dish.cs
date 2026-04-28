namespace RestaurantAPI.DAL;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
    public string Allergens { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
}
