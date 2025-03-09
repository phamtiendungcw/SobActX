using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Customers;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Customers.Commands.Customer.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerToDelete = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);
        if (customerToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Customers.Customer), request.Id).Message);
        await _customerRepository.DeleteAsync(customerToDelete, cancellationToken);

        return Result.Ok();
    }
}