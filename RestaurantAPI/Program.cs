using Microsoft.EntityFrameworkCore;
using RestaurantAPI.BLL;
using RestaurantAPI.DAL;

namespace RestaurantAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("RestaurantDb"));

            builder.Services.AddScoped<IMenuRepository, MenuRepository>();
            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<BookingService>();
            builder.Services.AddScoped<OrderService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (!context.Dishes.Any())
                {
                    context.Dishes.AddRange(
                        new Dish { Name = "Борщ український", Description = "Зі сметаною", Price = 150, Allergens = "Глютен", IsAvailable = true, PhotoUrl = "borsch.jpg" },
                        new Dish { Name = "Стейк Рибай", Description = "Мармурова яловичина", Price = 550, Allergens = "Немає", IsAvailable = true, PhotoUrl = "steak.jpg" },
                        new Dish { Name = "Салат Цезар", Description = "З куркою", Price = 220, Allergens = "Лактоза", IsAvailable = false, PhotoUrl = "caesar.jpg" }
                    );
                    context.SaveChanges();
                }
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
