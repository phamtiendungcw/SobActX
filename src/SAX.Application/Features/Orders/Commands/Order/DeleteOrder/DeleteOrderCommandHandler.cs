using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Orders.Commands.Order.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Result>
{
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Result> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToDelete = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);
        if (orderToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Orders.Order), request.Id).Message);

        await _orderRepository.DeleteAsync(orderToDelete, cancellationToken);

        return Result.Ok();
    }
}