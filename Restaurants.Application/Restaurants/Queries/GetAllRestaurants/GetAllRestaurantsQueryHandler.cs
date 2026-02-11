using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

// Change the IEnumerable to PagedResult
public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantRepository) : IRequestHandler<GetAllRestaurantsQuery, PagedResult<RestaurantDto>>
{
    public async Task<PagedResult<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurants");
        
        var (restaurants, totalCount) = await restaurantRepository.GetAllMatchingAsync(request.SearchPhrase,
            request.PageSize, 
            request.PageNumber);
        var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        
        // Add here
        var result = new PagedResult<RestaurantDto>(restaurantsDtos, totalCount,request.PageSize,request.PageNumber);

        // Change to return result
        return result;
    }
}
