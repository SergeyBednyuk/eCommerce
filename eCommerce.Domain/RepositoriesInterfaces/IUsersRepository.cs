using eCommerce.Domain.Entities;

namespace eCommerce.Domain.RepositoriesInterfaces;
/// <summary>
/// Interface be implemented by repository
/// that contains application user data access logic
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Method that add new application user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUserAsync(ApplicationUser user);
    /// <summary>
    /// Method that return application user
    /// by email and password
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password);
    
    /// <summary>
    /// Returns application user by user id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Application user object</returns>
    Task<ApplicationUser?> GetUserByUserIdAsync(Guid? userId);
}