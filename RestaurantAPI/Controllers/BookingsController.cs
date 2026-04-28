using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.BLL;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly BookingService _bookingService;
    public BookingsController(BookingService bookingService) => _bookingService = bookingService;

    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] BookingRequestDto dto)
    {
        var result = await _bookingService.CreateBookingAsync(dto);
        return CreatedAtAction(nameof(CreateBooking), result);
    }
}