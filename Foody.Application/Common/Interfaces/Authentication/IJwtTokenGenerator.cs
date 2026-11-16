using Foody.Domain.Entites;

namespace Foody.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}