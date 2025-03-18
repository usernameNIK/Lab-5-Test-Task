using Lab5TestTask.Data;
using Lab5TestTask.Models;
using Lab5TestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5TestTask.Services.Implementations;

/// <summary>
/// UserService implementation.
/// Implement methods here.
/// </summary>
public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> GetUserAsync()
    {
        return _users
        .OrderByDescending(u => u.Sessions.Count)
        .FirstOrDefault();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return _users
       .Where(u => u.Sessions.Any(s => s.DeviceType == DeviceType.Mobile))
       .ToList();
    }
}
