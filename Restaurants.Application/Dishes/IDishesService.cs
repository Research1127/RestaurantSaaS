using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes;

public interface IDishesService
{
    Task<IEnumerable<Dish>> GetAllDishes();
}