using FluentResults;

using MediatR;

namespace SAX.Application.Features.Customers.Commands.Customer.DeleteCustomer;

public record DeleteCustomerCommand : IRequest<Result>
{
    public Guid Id { get; set; }
}