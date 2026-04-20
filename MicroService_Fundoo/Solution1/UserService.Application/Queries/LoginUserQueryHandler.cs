using MediatR;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;


namespace UserService.Application.Queries;

public class LoginUserQueryHandler
    : IRequestHandler<LoginUserQuery, AuthResponseDto>
{
    private readonly IUserRepository _repo;
    private readonly IJwtService _jwtService;

    public LoginUserQueryHandler(IUserRepository repo, IJwtService jwtService)
    {
        _repo = repo;
        _jwtService = jwtService;
    }

    public async Task<AuthResponseDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _repo.GetByEmailAsync(request.Dto.Email)
            ?? throw new Exception("Invalid credentials");

        if (!BCrypt.Net.BCrypt.Verify(request.Dto.Password, user.PasswordHash))
            throw new Exception("Invalid credentials");

        var token = _jwtService.GenerateToken(user);

        return new AuthResponseDto(
            token,
            user.Email,
            $"{user.FirstName} {user.LastName}"
        );
    }
}
