namespace RestaurantAPI.BLL;

public interface IMenuService
{
    Task<IEnumerable<DishDto>> GetMenuAsync();
}