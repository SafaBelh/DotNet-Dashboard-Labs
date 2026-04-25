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
            .ToListAsync();
    }

    public async Task AddSensorAsync(SensorData sensor)
    {
        _context.Sensors.Add(sensor);
        await _context.SaveChangesAsync();
    }
}