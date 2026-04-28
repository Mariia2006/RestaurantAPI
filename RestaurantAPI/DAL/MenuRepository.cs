using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.DAL;

public class MenuRepository : IMenuRepository
{
    private readonly AppDbContext _context;

    public MenuRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Dish>> GetAvailableDishesAsync()
    {
        return await _context.Dishes.Where(d => d.IsAvailable).ToListAsync();
    }
}