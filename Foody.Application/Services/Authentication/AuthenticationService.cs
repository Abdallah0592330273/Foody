using ErrorOr;
using Foody.Application.Common.Interfaces;
using Foody.Application.Common.Interfaces.Persistance;
using Foody.Domain.Entites;

namespace Foody.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Register(User user)
    {
        var existsUser = await _userRepository.GetUserByEmail(user.Email);

        if (existsUser is not null)
        {
            return Error.Conflict("User already exists.");
        }

        await _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public async Task<ErrorOr<AuthenticationResult>> Login(string email, string password)
    {
        var user = await _userRepository.GetUserByEmail(email);

        if (user is null)
        {
            return Error.NotFound("No user registered with this email.");
        }

        if (password != user.Password)
        {
            return Error.Validation("Password is incorrect.");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
