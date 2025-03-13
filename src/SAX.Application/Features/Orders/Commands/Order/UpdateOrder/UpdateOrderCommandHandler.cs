using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Orders.Commands.Order.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateOrderCommand> _validator;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateOrderCommand> validator)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var orderDto = request.UpdateOrderDto;
        var order = await _unitOfWork.Repository<Domain.Entities.Orders.Order>().GetByIdAsync(orderDto.Id, cancellationToken);
        if (order == null) return Result.Fail(new SaxNotFoundException(nameof(Order), orderDto.Id).Message);
        _mapper.Map(orderDto, order);

        await _unitOfWork.Repository<Domain.Entities.Orders.Order>().UpdateAsync(order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}