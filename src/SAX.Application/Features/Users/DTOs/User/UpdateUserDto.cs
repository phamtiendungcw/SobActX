namespace SAX.Application.Features.Users.DTOs.User;

public class UpdateUserDto
{
    public Guid UserId { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}