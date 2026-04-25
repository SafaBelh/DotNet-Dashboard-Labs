using DashboardData.Models;

namespace DashboardData.Services;

public interface ISensorService
{
    List<SensorData> GetSensors();
    void AddSensor(SensorData sensor);
}