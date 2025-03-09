using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Promotions.Commands.Promotion.CreatePromotion;

public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, Result<Guid>>
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreatePromotionCommand> _validator;

    public CreatePromotionCommandHandler(IPromotionRepository promotionRepository, IMapper mapper, IValidator<CreatePromotionCommand> validator)
    {
        _promotionRepository = promotionRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var createPromotionDto = request.CreatePromotionDto;
        if (createPromotionDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu tạo khuyến mãi không hợp lệ: CreatePromotionDto không được null.").Message);

        var promotionToCreate = _mapper.Map<Domain.Entities.Promotions.Promotion>(createPromotionDto);
        var createdPromotion = await _promotionRepository.AddAsync(promotionToCreate, cancellationToken);

        return Result.Ok(createdPromotion.Id);
    }
}