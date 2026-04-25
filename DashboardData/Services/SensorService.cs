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

    public async Task<List<Location>> GetLocationsAsync()
    {
        return await _context.Locations.ToListAsync();
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


    // 🟣🟣🟣 Implmenting CRUD methods 
    public async Task<SensorData?> GetSensorByIdAsync(int id)
    {
        return await _context.Sensors
            .Include(s => s.Location)
            .Include(s => s.Tags)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task UpdateSensorAsync(SensorData sensor)
    {
        _context.Sensors.Update(sensor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSensorAsync(int id)
    {
        var sensor = await _context.Sensors.FindAsync(id);
        if (sensor != null)
        {
            _context.Sensors.Remove(sensor);
            await _context.SaveChangesAsync();
        }
    }

    // 🟣🟣🟣 Radzen KPIs
    public async Task<List<LocationStat>> GetAverageValueByLocationAsync()
    {
        return await _context.Sensors
            .Include(s => s.Location)
            .GroupBy(s => s.Location.Name)
            .Select(g => new LocationStat
            {
                LocationName = g.Key ?? "Inconnu",
                AverageValue = g.Average(s => s.Value)
            })
            .ToListAsync();
    }
    public async Task<List<LocationCountStat>> GetSensorCountByLocationAsync()
    {
        return await _context.Sensors
            .Include(s => s.Location)
            .GroupBy(s => s.Location.Name)
            .Select(g => new LocationCountStat
            {
                LocationName = g.Key ?? "Inconnu",
                Count = g.Count()
            })
            .ToListAsync();
    }
}