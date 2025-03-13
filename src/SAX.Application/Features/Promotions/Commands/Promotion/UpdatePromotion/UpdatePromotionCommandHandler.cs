using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Promotions.Commands.Promotion.UpdatePromotion;

public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand, Result>
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdatePromotionCommand> _validator;

    public UpdatePromotionCommandHandler(IPromotionRepository promotionRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdatePromotionCommand> validator)
    {
        _promotionRepository = promotionRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var promotionDto = request.UpdatePromotionDto;
        var promotion = await _unitOfWork.Repository<Domain.Entities.Promotions.Promotion>().GetByIdAsync(promotionDto.Id, cancellationToken);
        if (promotion == null) return Result.Fail(new SaxNotFoundException(nameof(Promotion), promotionDto.Id).Message);
        _mapper.Map(promotionDto, promotion);

        await _unitOfWork.Repository<Domain.Entities.Promotions.Promotion>().UpdateAsync(promotion, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}