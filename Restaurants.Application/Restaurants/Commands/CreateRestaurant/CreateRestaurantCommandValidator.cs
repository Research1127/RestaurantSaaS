using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);
        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required");
        RuleFor(dto => dto.Category)
            .NotEmpty().WithMessage("Insert a valid category");
        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("Please give a valid email address");
        RuleFor(dto => dto.ContactNumber)
            .Length(5,15).WithMessage("Please give a valid number");
        RuleFor(dto => dto.PostalCode)
            .Matches("^[0-9]{5}$").WithMessage("Insert valid postal code: 12345");
        
    }
}