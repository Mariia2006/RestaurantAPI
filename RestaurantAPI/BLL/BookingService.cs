namespace RestaurantAPI.BLL;
using RestaurantAPI.DAL;

public class BookingService
{
    private readonly AppDbContext _context;
    public BookingService(AppDbContext context) => _context = context;

    public async Task<BookingResponseDto> CreateBookingAsync(BookingRequestDto dto)
    {
        var booking = new Booking
        {
            CustomerName = dto.CustomerName,
            Phone = dto.Phone,
            Date = DateTime.Parse($"{dto.Date} {dto.Time}"),
            GuestsCount = dto.GuestsCount
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return new BookingResponseDto
        {
            BookingId = booking.Id,
            Status = "Confirmed",
            Message = $"Столик успішно заброньовано на {dto.GuestsCount} особи."
        };
    }
}