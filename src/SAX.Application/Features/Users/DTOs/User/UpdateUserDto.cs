namespace SAX.Application.Features.Users.DTOs.User;

public class UpdateUserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string? Password { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public DateTime? LastLoginDate { get; set; }
}