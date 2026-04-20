using MediatR;
using UserService.Application.DTOs;

namespace UserService.Application.Commands;

public record RegisterUserCommand(RegisterUserDto Dto) : IRequest<string>;