using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Customers;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Customers.Commands.Customer.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerToDelete = await _unitOfWork.Repository<Domain.Entities.Customers.Customer>().GetByIdAsync(request.Id, cancellationToken);
        if (customerToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Customers.Customer), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Customers.Customer>().DeleteAsync(customerToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}