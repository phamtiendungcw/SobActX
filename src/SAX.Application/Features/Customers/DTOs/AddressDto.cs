namespace SAX.Application.Features.Customers.DTOs;

public class AddressDto
{
    public Guid AddressId { get; set; }
    public string StreetAddress { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string Country { get; set; } = string.Empty;
}