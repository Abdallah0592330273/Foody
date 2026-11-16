using System.Security.Cryptography.X509Certificates;
using Foody.Domain.Entites;

namespace Foody.Application.Authentication;
public sealed record AuthenticationResult(
    User user,
    string token);