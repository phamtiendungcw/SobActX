using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Customers;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Customers.Commands.Customer.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<Guid>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCustomerCommand> _validator;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IValidator<CreateCustomerCommand> validator)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var createCustomerDto = request.CreateCustomerDto;
        var customerToCreate = _mapper.Map<Domain.Entities.Customers.Customer>(createCustomerDto);
        var createdCustomer = await _customerRepository.AddAsync(customerToCreate, cancellationToken);

        return Result.Ok(createdCustomer.Id);
    }
}