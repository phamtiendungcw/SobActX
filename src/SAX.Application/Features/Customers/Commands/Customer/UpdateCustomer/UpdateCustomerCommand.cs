using FluentResults;

using MediatR;

using SAX.Application.Features.Customers.DTOs.Customer;

namespace SAX.Application.Features.Customers.Commands.Customer.UpdateCustomer;

public abstract record UpdateCustomerCommand(UpdateCustomerDto UpdateCustomerDto) : IRequest<Result>;