using Microsoft.EntityFrameworkCore;
using Restaurants.Application.Dishes;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class DishesRepository(RestaurantsDbContext dbContext) : IDishesRepository
{
    public async Task<IEnumerable<Dish>> GetAllAsync()
    {
        var dishes = await dbContext.Dishes.ToListAsync();
        return dishes;
    }
}


