using Foody.Domain.Entites;

namespace Foody.Application.Common.Interfaces.Persistance;
public interface IUserRepository
{
    Task Add(User user);
    Task<User?> GetUserByEmail(string email);
}