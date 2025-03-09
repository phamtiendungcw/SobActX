﻿using FluentValidation;

using SAX.Application.Features.Marketing.DTOs.EmailCampaign;

namespace SAX.Application.Features.Marketing.Validators;

public class EmailCampaignDtoValidator : AbstractValidator<EmailCampaignDto>
{
    public EmailCampaignDtoValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.CampaignId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
        RuleFor(p => p.EmailTemplateId)
            .NotEmpty().WithMessage("{PropertyName} không được để trống.")
            .NotNull().WithMessage("{PropertyName} không được null.");
    }
}