using DashboardData.Models;

namespace DashboardData.Services;

public interface ISensorService
{
    Task<List<SensorData>> GetSensorsAsync();
    Task AddSensorAsync(SensorData sensor);
    Task<List<Location>> GetLocationsAsync();
    Task<int> GetTotalCountAsync();
    Task<double> GetAverageValueAsync();
    Task<double> GetMaxValueAsync();
    Task<List<SensorData>> GetCriticalSensorsAsync(double threshold);
    Task<SensorData?> GetSensorByIdAsync(int id);
    Task UpdateSensorAsync(SensorData sensor);
    Task DeleteSensorAsync(int id);
    Task<List<LocationStat>> GetAverageValueByLocationAsync();
    Task<List<LocationCountStat>> GetSensorCountByLocationAsync();
}