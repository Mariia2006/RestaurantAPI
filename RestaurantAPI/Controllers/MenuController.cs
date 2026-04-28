using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.BLL;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMenu()
    {
        var menu = await _menuService.GetMenuAsync();
        return Ok(menu);
    }
}