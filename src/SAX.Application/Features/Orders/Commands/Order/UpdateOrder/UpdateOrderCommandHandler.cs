using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Orders.Commands.Order.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IValidator<UpdateOrderCommand> _validator;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IValidator<UpdateOrderCommand> validator)
    {
        _orderRepository = orderRepository;
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

        var updateOrderDto = request.UpdateOrderDto;
        if (updateOrderDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu cập nhật đặt hàng không hợp lệ: UpdateOrderDto không được null.").Message);

        var orderToUpdate = await _orderRepository.GetByIdAsync(updateOrderDto.Id, cancellationToken);
        if (orderToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Orders.Order), updateOrderDto.Id).Message);

        _mapper.Map(updateOrderDto, orderToUpdate);
        await _orderRepository.UpdateAsync(orderToUpdate, cancellationToken);

        return Result.Ok();
    }
}