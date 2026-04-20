using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Commands;
using UserService.Application.DTOs;
using UserService.Application.Queries;
using Microsoft.AspNetCore.Authorization;


namespace UserService.API.Controllers;



[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto dto)
    {
        var userId = await _mediator.Send(new RegisterUserCommand(dto));
        return Ok(new { userId });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result = await _mediator.Send(new LoginUserQuery(dto));
        return Ok(result);
    }

    [Authorize]
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        return Ok("You are authorized 🔥");
    }
}