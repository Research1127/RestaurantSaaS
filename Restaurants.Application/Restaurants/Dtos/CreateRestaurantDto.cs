using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants.Dtos;

public class CreateRestaurantDto
{
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    
    [Required(ErrorMessage = "Please insert a valid category")]
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    
    [EmailAddress(ErrorMessage = "Please give a valid email address"), MaxLength(30)]
    public string? ContactEmail { get; set; }
    [Phone(ErrorMessage = "Please give a valid phone number"), MaxLength(15)]
    public string? ContactNumber { get; set; }
    
    public string? City { get; set; }
    public string? Street { get; set; }
    
    [RegularExpression("^[0-9]{5}$", ErrorMessage = "Please give a valid postal code = 64579")]
    public string? PostalCode { get; set; }
}