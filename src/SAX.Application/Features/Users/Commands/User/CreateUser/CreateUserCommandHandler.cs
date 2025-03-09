using AutoMapper;

using FluentResults;

using FluentValidation;

using MediatR;

using SAX.Application.Common.Contracts.Persistence.Repositories.Users;
using SAX.Application.Common.Exceptions;

namespace SAX.Application.Features.Users.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateUserCommand> _validator;

    public CreateUserCommandHandler(IUserRepository repository, IMapper mapper, IValidator<CreateUserCommand> validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return Result.Fail(new SaxValidationException(validationResult.Errors).Message).WithErrors(errors);
        }

        var createUserDto = request.CreateUserDto;
        if (createUserDto == null) return Result.Fail(new SaxBadRequestException("Dữ liệu tạo người dùng không hợp lệ: CreateUserDto không được null.").Message);

        var userToCreate = _mapper.Map<Domain.Entities.Users.User>(createUserDto);
        var createdUser = await _repository.AddAsync(userToCreate, cancellationToken);

        return Result.Ok(createdUser.Id);
    }
}