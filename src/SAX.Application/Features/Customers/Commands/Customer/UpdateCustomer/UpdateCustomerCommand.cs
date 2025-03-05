using FluentResults;

using MediatR;

using SAX.Application.Features.Customers.DTOs.Customer;

namespace SAX.Application.Features.Customers.Commands.Customer.UpdateCustomer;

public record UpdateCustomerCommand : IRequest<Result>
{
    public UpdateCustomerDto? UpdateCustomerDto { get; set; }
}