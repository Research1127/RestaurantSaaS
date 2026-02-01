using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }  
        
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
        [
            new(UserRoles.User),
            new(UserRoles.Owner),
            new(UserRoles.Admin),
        ];
        return roles;
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
        new()
        {
            Name = "KFC",
            Category = "Food",
            Description = "KFC restaurants",
            ContactEmail = "kfc@gmail.com",
            HasDelivery =  true,
            Dishes = [
            new()
            {
                Name = "Snack Plate",
                Description = "Chicken and coslo",
                Price = 10,
            },
            
            new()
            {
            Name = "Chicken Tender",
            Description = "Chicken and water",
            Price = 14,
            },
            ],
            
            Address = new()
            {
                City = "Selangor",
                Street = "Petaling Jaya",
                PostalCode =  "98052",
            }
        },
        new Restaurant()
        {
            Name = "McDonalds",
            Category = "Food",
            Description = "McDonalds restaurants",
            ContactEmail = "McDonalds@gmail.com",
            HasDelivery =  true,
            Dishes = [
                new()
                {
                    Name = "McDonalds Plate",
                    Description = "Chicken and McDonalds",
                    Price = 10,
                },
        
                new()
                {
                    Name = "Chicken McDonalds",
                    Description = "McDonalds and water",
                    Price = 14,
                },
            ],
        
            Address = new()
            {
                City = "Kelantan",
                Street = "Kota Bharu",
                PostalCode =  "32343",
            }
        }
        ];
        
        return restaurants;

    }

}