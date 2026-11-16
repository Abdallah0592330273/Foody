using ErrorOr;
using Foody.Domain.Entites;

namespace Foody.Application.Authentication;

public interface IAuthenticationService
{
    Task<ErrorOr<AuthenticationResult>> Register(User user);
    Task<ErrorOr<AuthenticationResult>> Login(string email, string password);
}
