using MediatR;
using UserService.Application.DTOs;

namespace UserService.Application.Queries;

public record LoginUserQuery(LoginDto Dto) : IRequest<AuthResponseDto>;
