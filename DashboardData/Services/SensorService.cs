using DashboardData.Models;

namespace DashboardData.Services;

public class SensorService : ISensorService
{
    private List<SensorData> _sensors = new()
    {
        new SensorData { Name = "Temp_Salon", Value = 22.5 },
        new SensorData { Name = "Hum_Cuisine", Value = 45.0 },
        new SensorData { Name = "CO2_Bureau", Value = 800 }
    };

    public List<SensorData> GetSensors()
    {
        return _sensors;
    }
    public void AddSensor(SensorData sensor)
    {
        _sensors.Add(sensor);
    }
}