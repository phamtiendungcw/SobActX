using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Customers;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Customers.Commands.Customer.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateCustomerCommand> _validator;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateCustomerCommand> validator)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var customerDto = request.UpdateCustomerDto;
        var customerToUpdate = await _unitOfWork.Repository<Domain.Entities.Customers.Customer>().GetByIdAsync(customerDto.Id, cancellationToken);
        if (customerToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Customers.Customer), customerDto.Id).Message);
        _mapper.Map(customerDto, customerToUpdate);

        await _unitOfWork.Repository<Domain.Entities.Customers.Customer>().UpdateAsync(customerToUpdate, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}