using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using VgWebApp.Models;

namespace VgWebApp.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "Mortal Kombat",
                    Description = "Violent",
                    Genre = "Fighting",
                    Price = 59.99m,
                    ESRB = "Mature",
                    Rating = 90,
                    Multiplayer = true
                },
                new Product
                {
                    Name = "Starcraft",
                    Description = "Warcraft in space",
                    Genre = "Strategy",
                    Price = 49.95m,
                    ESRB = "Teen",
                    Rating = 95,
                    Multiplayer = true
                },
                new Product
                {
                    Name = "Half-Life",
                    Description = "Aliens and science",
                    Genre = "Shooter",
                    Price = 29.95m,
                    ESRB = "Teen",
                    Rating = 99,
                    Multiplayer = true
                },
                new Product
                {
                    Name = "Super Meat Boy",
                    Description = "Boy of meat jumping",
                    Genre = "Platformer",
                    Price = 19.95m,
                    ESRB = "Kids",
                    Rating = 85,
                    Multiplayer = false
                },
                new Product
                {
                    Name = "New Japan All Stars 4",
                    Description = "Baseball star dating simulator",
                    Genre = "Adult",
                    Price = 19.95m,
                    ESRB = "Mature",
                    Rating = 67,
                    Multiplayer = false
                },
                new Product
                {
                    Name = "Puzzle Bobble",
                    Description = "Cute girls will play this with you",
                    Genre = "Puzzle",
                    Price = 9.95m,
                    ESRB = "Kids",
                    Rating = 75,
                    Multiplayer = true
                },
                new Product
                {
                    Name = "Unsteady Chair",
                    Description = "The chair could fall over at any moment",
                    Genre = "Puzzle",
                    Price = 29.95m,
                    ESRB = "Kids",
                    Rating = 72,
                    Multiplayer = true
                },
                new Product
                {
                    Name = "Battle Chess",
                    Description = "An attempt to make chess exciting",
                    Genre = "Chess",
                    Price = 15.99m,
                    ESRB = "Teen",
                    Rating = 82,
                    Multiplayer = true
                },
                new Product
                {
                    Name = "King Kong's Hawaiian Vacation",
                    Description = "King Kong sitting on a beach",
                    Genre = "Simulation",
                    Price = 5.99m,
                    ESRB = "Teen",
                    Rating = 100,
                    Multiplayer = true
                }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
