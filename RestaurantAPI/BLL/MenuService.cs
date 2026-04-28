using RestaurantAPI.DAL;

namespace RestaurantAPI.BLL;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _repository;

    public MenuService(IMenuRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DishDto>> GetMenuAsync()
    {
        var dishes = await _repository.GetAvailableDishesAsync();

        return dishes.Select(d => new DishDto
        {
            Id = d.Id,
            Name = d.Name,
            Description = d.Description,
            Price = d.Price,
            PhotoUrl = d.PhotoUrl,
            Allergens = d.Allergens
        });
    }
}