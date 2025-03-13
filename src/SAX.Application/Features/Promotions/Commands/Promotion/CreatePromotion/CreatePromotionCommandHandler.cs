using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Promotions;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Promotions.Commands.Promotion.CreatePromotion;

public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, Result<Guid>>
{
    private readonly IPromotionRepository _promotionRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CreatePromotionCommand> _validator;

    public CreatePromotionCommandHandler(IPromotionRepository promotionRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreatePromotionCommand> validator)
    {
        _promotionRepository = promotionRepository;
        _unitOfWork = unitOfWork;
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

        var promotionDto = request.CreatePromotionDto;
        var promotion = _mapper.Map<Domain.Entities.Promotions.Promotion>(promotionDto);

        await _unitOfWork.Repository<Domain.Entities.Promotions.Promotion>().AddAsync(promotion, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(promotion.Id);
    }
}