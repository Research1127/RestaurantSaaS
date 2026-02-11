using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

// Change IRequest<IEnumerable<RestaurantDto>> to IRequest<PagedResult<RestaurantDto>>
public class GetAllRestaurantsQuery : IRequest<PagedResult<RestaurantDto>>
{
    public string? SearchPhrase {get; set;}
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
