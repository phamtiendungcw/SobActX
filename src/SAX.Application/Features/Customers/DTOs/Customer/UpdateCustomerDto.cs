namespace SAX.Application.Features.Customers.DTOs.Customer;

public class UpdateCustomerDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Guid? AddressId { get; set; }
}