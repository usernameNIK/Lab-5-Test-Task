using Lab5TestTask.Data;
using Lab5TestTask.Models;
using Lab5TestTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab5TestTask.Services.Implementations;

/// <summary>
/// SessionService implementation.
/// Implement methods here.
/// </summary>
public class SessionService : ISessionService
{
    private readonly ApplicationDbContext _dbContext;

    public SessionService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Session> GetSessionAsync()
    {
        return _sessions
        .Where(s => s.DeviceType == DeviceType.Desktop)
        .OrderBy(s => s.StartTime)
        .FirstOrDefault();
    }

    public async Task<List<Session>> GetSessionsAsync()
    {
        return _sessions
       .Where(s => s.User.IsActive && s.EndTime.Year < 2025)
       .ToList();
    }
}
