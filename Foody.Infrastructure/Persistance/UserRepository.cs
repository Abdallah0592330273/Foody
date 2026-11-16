using Foody.Application.Common.Interfaces.Persistance;
using Foody.Domain.Entites;
using Microsoft.Extensions.Logging;

namespace Foody.Infrastructure.Persistance;

public class UserRepository : IUserRepository
{
    private readonly ILogger<UserRepository> _logger;

    // جعلنا القائمة static عشان تفضل البيانات محفوظة وما تتبخرش مع كل طلب HTTP جديد
    private static readonly List<User> _users = new List<User>();

    public UserRepository(ILogger<UserRepository> logger)
    {
        _logger = logger;
    }

    public async Task Add(User user)
    {
        _users.Add(user);
        await Task.CompletedTask;
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        User? existsUser =_users.FirstOrDefault(u => u.Email == email);
        return await Task.FromResult(existsUser);
    }
}