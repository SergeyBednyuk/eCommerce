using eCommerce.Application.Utils;

namespace eCommerce.Application.Dtos;

public record RegisterRequest(
    string Email, 
    string Password,  
    string FirstName, 
    string LastName, 
    GenderOptions Gender);