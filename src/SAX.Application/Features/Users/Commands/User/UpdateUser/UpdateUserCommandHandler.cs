using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Users.Commands.User.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateUserCommand> _validator;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IValidator<UpdateUserCommand> validator)
    {
        _userRepository = userRepository;
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

        var updateUserDto = request.UpdateUserDto;
        if (updateUserDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu cập nhật người dùng không hợp lệ: UpdateUserDto không được null.").Message);

        var userToUpdate = await _userRepository.GetByIdAsync(updateUserDto.Id, cancellationToken);
        if (userToUpdate == null) return Result.Fail(new SaxNotFoundException(nameof(Domain.Entities.Users.User), updateUserDto.Id).Message);

        _mapper.Map(updateUserDto, userToUpdate);
        await _userRepository.UpdateAsync(userToUpdate, cancellationToken);

        return Result.Ok();
    }
}