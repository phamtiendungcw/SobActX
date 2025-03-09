using SAX.Application.Features.Orders.DTOs;
using SAX.Application.Features.Orders.DTOs.Order;
using SAX.Application.Features.Products.DTOs.ProductReview;

namespace SAX.Application.Features.Customers.DTOs.Customer;

public class CustomerDetailsDto : CustomerDto
{
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Country { get; set; }
}