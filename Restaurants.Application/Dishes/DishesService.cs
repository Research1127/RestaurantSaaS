using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes;

internal class DishesService(IDishesRepository dishesRepository,
    ILogger<DishesService> logger) : IDishesService
{
    public async Task<IEnumerable<Dish>> GetAllDishes()
    {
        logger.LogInformation("Getting all dishes");
        var dishes = await dishesRepository.GetAllAsync();
        return dishes;
    }
}
