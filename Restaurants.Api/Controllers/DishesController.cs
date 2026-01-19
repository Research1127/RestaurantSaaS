using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Commands;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries;
using Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant;
using Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Api.Controllers;

[ApiController]
[Route("api/restaurant/{restaurantId}/dishes")] 
// Example api/restaurant/5/dishes

public class DishesController(IMediator mediator) : ControllerBase

{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] int restaurantId,
        CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        await mediator.Send(command);
        return Created();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
        return Ok(dishes);
    }
    
    [HttpGet("{dishId}")]
    public async Task<ActionResult<DishDto>> GetByIdForRestaurant([FromRoute] int restaurantId, [FromRoute]int dishId)
    {
        var dish = await mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId,dishId));
        return Ok(dish);
    }
}
