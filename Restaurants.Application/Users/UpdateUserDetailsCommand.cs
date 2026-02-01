using MediatR;

namespace Restaurants.Application.Users;

public class UpdateUserDetailsCommand :  IRequest
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
}