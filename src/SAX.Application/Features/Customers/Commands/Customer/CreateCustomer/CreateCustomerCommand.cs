using FluentResults;

using MediatR;

using SAX.Application.Features.Customers.DTOs.Customer;

namespace SAX.Application.Features.Customers.Commands.Customer.CreateCustomer;

public abstract record CreateCustomerCommand(CreateCustomerDto CreateCustomerDto) : IRequest<Result<Guid>>;