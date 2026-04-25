using DashboardData.Models;
using DashboardData.Data;
using Microsoft.EntityFrameworkCore;

namespace DashboardData.Services;

public class SensorService : ISensorService
{
    private readonly AppDbContext _context;

    public SensorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SensorData>> GetSensorsAsync()
    {
        return await _context.Sensors
            .Include(s => s.Location)
            .Include(s => s.Tags)
            .ToListAsync();
    }

    public async Task AddSensorAsync(SensorData sensor)
    {
        _context.Sensors.Add(sensor);
        await _context.SaveChangesAsync();
    }


    // 🟣🟣🟣 KPIs METHODS 
    public async Task<int> GetTotalCountAsync()
    {
        return await _context.Sensors.CountAsync();
    }

    public async Task<double> GetAverageValueAsync()
    {
      
        if (!await _context.Sensors.AnyAsync())
            return 0;
        return await _context.Sensors.AverageAsync(s => s.Value);
    }

    public async Task<double> GetMaxValueAsync()
    {
        if (!await _context.Sensors.AnyAsync())
            return 0;
        return await _context.Sensors.MaxAsync(s => s.Value);
    }

    public async Task<List<SensorData>> GetCriticalSensorsAsync(double threshold)
    {
        return await _context.Sensors
            .Include(s => s.Location)
            .Include(s => s.Tags)
            .Where(s => s.Value > threshold)
            .OrderByDescending(s => s.Value)
            .ToListAsync();
    }
}