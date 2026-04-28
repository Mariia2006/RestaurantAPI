namespace RestaurantAPI.BLL;

public class DishDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string PhotoUrl { get; set; } = string.Empty;
    public string Allergens { get; set; } = string.Empty;
}