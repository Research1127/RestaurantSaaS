using MediatR;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant;

public class GetDishByIdForRestaurantQuery(int restaurantId, int dishId) : IRequest<DishDto>
{
    public int RestaurantId { get; } = restaurantId;
    public int DishId { get; } = dishId;
}