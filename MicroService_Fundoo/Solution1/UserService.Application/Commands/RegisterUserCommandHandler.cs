using MediatR;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.Commands;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
{
    private readonly IUserRepository _repo;

    public RegisterUserCommandHandler(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var existingUser = await _repo.GetByEmailAsync(dto.Email);
        if (existingUser != null)
        {
            throw new Exception("User already exists");
        }

        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        return await _repo.AddAsync(user);
    }
}