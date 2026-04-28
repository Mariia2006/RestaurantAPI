namespace RestaurantAPI.DAL;

public interface IMenuRepository
{
    Task<IEnumerable<Dish>> GetAvailableDishesAsync();
}