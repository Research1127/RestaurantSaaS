using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Commands;
using Restaurants.Application.Dishes.Commands.CreateDish;

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
}
