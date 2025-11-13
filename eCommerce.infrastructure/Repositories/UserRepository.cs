using eCommerce.Application.Utils;
using eCommerce.Domain.Entities;
using eCommerce.Domain.RepositoriesInterfaces;

namespace eCommerce.infrastructure.Repositories;

internal class UserRepository : IUsersRepository
{
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        //Generate new guid
        user.UserID = Guid.NewGuid();

        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password)
    {
        return new ApplicationUser
        {
            UserID = Guid.NewGuid(),
            Email = email,
            Pasword = password,
            FirstName = "FirstName",
            LastName = "LastName",
            Gender = nameof(GenderOptions.Other)
        };
    }
}