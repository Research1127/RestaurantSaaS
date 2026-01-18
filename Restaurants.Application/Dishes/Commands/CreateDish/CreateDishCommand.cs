using MediatR;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommand : IRequest
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; } // Must validate
    public int? KiloCalories { get; set; } // Must validate
    public int RestaurantId { get; set; }
}

