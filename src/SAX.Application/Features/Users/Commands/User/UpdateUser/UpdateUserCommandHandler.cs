using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence;
using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Users.Commands.User.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IValidator<UpdateUserCommand> _validator;

    public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateUserCommand> validator)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var userDto = request.UpdateUserDto;
        var user = await _unitOfWork.Repository<Domain.Entities.Users.User>().GetByIdAsync(userDto.Id, cancellationToken);
        if (user == null) return Result.Fail(new SaxNotFoundException(nameof(User), userDto.Id).Message);
        _mapper.Map(userDto, user);

        await _unitOfWork.Repository<Domain.Entities.Users.User>().UpdateAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}