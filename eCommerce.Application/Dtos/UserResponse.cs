namespace eCommerce.Application.Dtos;

public class UserResponse<T> where T : class
{
    public bool IsSuccess { get; set; }

    public T? Data { get; set; }

    public string? Message { get; set; }

    public IEnumerable<string>? Errors { get; set; }

    private UserResponse(bool isSuccess, T? data, string? message, IEnumerable<string>? errors)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
        Errors = errors;
    }

    public static UserResponse<T> Success(T data, string? message = null)
    {
        return new UserResponse<T>(true, data, message, null);
    }

    public static UserResponse<T> Failure(T? data, string? message, IEnumerable<string>? errors = null)
    {
        return new UserResponse<T>(false, data, message, errors);
    }
}