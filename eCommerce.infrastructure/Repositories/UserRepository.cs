using Dapper;
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

        var query =
            "INSERT INTO \"ApplicationUsers\" (\"UserId\", \"Email\", \"Password\", \"FirstName\", \"LastName\", \"Gender\")" +
            "VALUES (@UserId, @Email, @Password, @FirstName, @LastName, @Gender)";

        var rows = await _context.DbConnection.ExecuteAsync(query, user);

        return rows > 0 ? user : null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password)
    {
        var query = "SELECT * FROM \"ApplicationUsers\" WHERE \"Email\"=@Email AND \"Password\"=@Password";

        var result = await _context.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { email, password });

        return result;
    }

    public async Task<ApplicationUser?> GetUserByUserIdAsync(Guid? userId)
    {
        var query = "SELECT * FROM \"ApplicationUsers\" WHERE \"UserId\"=@UserId";
        
        var result = await _context.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { userId });

        return result;
    }
}