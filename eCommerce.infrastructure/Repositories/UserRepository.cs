using Dapper;
using eCommerce.Application.Utils;
using eCommerce.Domain.Entities;
using eCommerce.Domain.RepositoriesInterfaces;
using eCommerce.infrastructure.DbContext;

namespace eCommerce.infrastructure.Repositories;

internal class UserRepository(DapperDbContext context) : IUsersRepository
{
    private readonly DapperDbContext _context = context;

    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        //Generate new guid
        user.UserId = Guid.NewGuid();

        var query = @"
        INSERT INTO Users (UserId, Email, Password, FirstName, LastName, Gender) 
        VALUES (@UserId, @Email, @Pasword, @FirstName, @LastName, @Gender)";
        
        var rows = await _context.DbConnection.ExecuteAsync(query, user);
        
        return rows > 0 ? user :  null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password)
    {
        await Task.Delay(1000);
        
        return new ApplicationUser
        {
            UserId = Guid.NewGuid(),
            Email = email,
            Pasword = password,
            FirstName = "FirstName",
            LastName = "LastName",
            Gender = nameof(GenderOptions.Other)
        };
    }
}