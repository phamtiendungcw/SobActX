using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Orders.Commands.Order.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<Guid>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateOrderCommand> _validator;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateOrderCommand> validator)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail<Guid>(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var orderDto = request.CreateOrderDto;
        var order = _mapper.Map<Domain.Entities.Orders.Order>(orderDto);

        await _unitOfWork.Repository<Domain.Entities.Orders.Order>().AddAsync(order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(order.Id);
    }
}