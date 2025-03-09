using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Promotions.Commands.Promotion.UpdatePromotion;

public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand, Result>
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdatePromotionCommand> _validator;

    public UpdatePromotionCommandHandler(IPromotionRepository promotionRepository, IMapper mapper, IValidator<UpdatePromotionCommand> validator)
    {
        _promotionRepository = promotionRepository;
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

        var updatePromotionDto = request.UpdatePromotionDto;
        if (updatePromotionDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu cập nhật khuyến mãi không hợp lệ: UpdatePromotionDto không được null.").Message);

        var promotionToUpdate = await _promotionRepository.GetByIdAsync(updatePromotionDto.Id, cancellationToken);
        if (promotionToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Promotions.Promotion), updatePromotionDto.Id).Message);

        _mapper.Map(updatePromotionDto, promotionToUpdate);
        await _promotionRepository.UpdateAsync(promotionToUpdate, cancellationToken);

        return Result.Ok();
    }
}