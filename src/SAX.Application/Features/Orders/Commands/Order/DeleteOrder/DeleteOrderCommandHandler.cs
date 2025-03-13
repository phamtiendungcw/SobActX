using FluentResults;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Orders;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Orders.Commands.Order.DeleteOrder;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Result>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToDelete = await _unitOfWork.Repository<Domain.Entities.Orders.Order>().GetByIdAsync(request.Id, cancellationToken);
        if (orderToDelete == null) return Result.Fail(new SaxNotFoundException(nameof(Order), request.Id).Message);

        await _unitOfWork.Repository<Domain.Entities.Orders.Order>().DeleteAsync(orderToDelete, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}