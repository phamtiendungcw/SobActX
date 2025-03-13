using FluentResults;

using MediatR;

namespace SAX.Application.Features.Customers.Commands.Customer.DeleteCustomer;

public abstract record DeleteCustomerCommand(Guid Id) : IRequest<Result>;