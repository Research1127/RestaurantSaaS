using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantRepository, 
    ILogger<RestaurantsService> logger,
    IMapper mapper): IRestaurantsService
{
    public async Task<int> Create(CreateRestaurantDto dto)
    {
        logger.LogInformation($"Creating a new Restaurant");
        var restaurant = mapper.Map<Restaurant>(dto);
        int id = await restaurantRepository.Create(restaurant);
        return id;
    }
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantRepository.GetAllAsync();
        var restaurantsDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        
        return restaurantsDtos!;
    }

    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation($"Getting Restaurant {id}");
        var restaurant = await restaurantRepository.GetByIdAsync(id);
        var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);
        return restaurantDto;
        
    }
}
