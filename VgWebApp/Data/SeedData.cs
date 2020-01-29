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
                    Category = "Fighting",
                    Price = 59.99m
                },
                new Product
                {
                    Name = "Starcraft",
                    Description = "Warcraft in space",
                    Category = "Strategy",
                    Price = 49.95m
                },
                new Product
                {
                    Name = "Half-Life",
                    Description = "Aliens and science",
                    Category = "Shooter",
                    Price = 29.95m
                },
                new Product
                {
                    Name = "Super Meat Boy",
                    Description = "Boy of meat jumping",
                    Category = "Platformer",
                    Price = 19.95m
                },
                new Product
                {
                    Name = "New Japan All Stars 4",
                    Description = "Baseball star dating simulator",
                    Category = "Adult",
                    Price = 19.95m
                },
                new Product
                {
                    Name = "Puzzle Bobble",
                    Description = "Cute girls will play this with you",
                    Category = "Puzzke",
                    Price = 9.95m
                },
                new Product
                {
                    Name = "Unsteady Chair",
                    Description = "The chair could fall over at any moment",
                    Category = "Puzzle",
                    Price = 29.95m
                },
                new Product
                {
                    Name = "Battle Chess",
                    Description = "An attempt to make chess exciting",
                    Category = "Chess",
                    Price = 15.99m
                },
                new Product
                {
                    Name = "King Kong's Hawaiian Vacation",
                    Description = "King Kong sitting on a beach",
                    Category = "Simulation",
                    Price = 5.99m
                }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
