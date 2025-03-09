using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Customers;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Customers.Commands.Customer.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateCustomerCommand> _validator;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IValidator<UpdateCustomerCommand> validator)
    {
        _customerRepository = customerRepository;
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

        var updateCustomerDto = request.UpdateCustomerDto;
        if (updateCustomerDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu cập nhật khách hàng không hợp lệ: UpdateCustomerDto không được null.").Message);

        var customerToUpdate = await _customerRepository.GetByIdAsync(updateCustomerDto.Id, cancellationToken);
        if (customerToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Customers.Customer), updateCustomerDto.Id).Message);

        _mapper.Map(request.UpdateCustomerDto, customerToUpdate);
        await _customerRepository.UpdateAsync(customerToUpdate, cancellationToken);

        return Result.Ok();
    }
}