using FluentResults;

using MediatR;

using SAX.Application.Features.Customers.DTOs.Customer;

namespace SAX.Application.Features.Customers.Commands.Customer.CreateCustomer;

public record CreateCustomerCommand : IRequest<Result<Guid>>
{
    public CreateCustomerDto? CreateCustomerDto { get; set; }
}