using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdHandler(ILogger<GetRestaurantByIdHandler> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantRepository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting Restaurant {request.Id}");
        var restaurant = await restaurantRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"Restaurant with id {request.Id} doesn't exist");;
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
        return restaurantDto;
    }
}