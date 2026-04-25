using DashboardData.Models;

namespace DashboardData.Services;

public interface ISensorService
{
    Task<List<SensorData>> GetSensorsAsync();
    Task AddSensorAsync(SensorData sensor);
}