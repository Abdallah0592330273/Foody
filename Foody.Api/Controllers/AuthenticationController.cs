using Foody.Application.Authentication;
using Foody.Contracts.Authentication;
using Foody.Domain.Entites;
using Microsoft.AspNetCore.Mvc;

namespace Foody.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var user = new User(request.FirstName, request.LastName, request.Email, request.Password);
        var result = await _authenticationService.Register(user);

        return result.Match(
            authResult => Ok(MapResult(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authenticationService.Login(
            request.Email,
            request.Password
        );

        return result.Match(
            authResult => Ok(MapResult(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapResult(AuthenticationResult result)
    {
        return new AuthenticationResponse(
            Id: result.user.Id,
            FirstName: result.user.FirstName,
            LastName: result.user.LastName,
            Email: result.user.Email,
            Token: result.token
        );
    }
}
