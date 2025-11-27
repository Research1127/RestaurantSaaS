using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes;

namespace Restaurants.Api.Controllers;

[ApiController]
[Route("api/dishes")]

public class DishesController(IDishesService dishesService) : ControllerBase

{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dishes = await dishesService.GetAllDishes();
        return Ok(dishes);
    }
}