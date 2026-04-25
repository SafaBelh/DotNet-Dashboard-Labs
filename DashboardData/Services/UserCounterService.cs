using System;

namespace DashboardData.Services;

public class UserCounterService
{
    private static int _instanceCounter = 0;
    public int InstanceId { get; }
    public int Count { get; private set; }

    public UserCounterService()
    {
        InstanceId = ++_instanceCounter;
        Console.WriteLine($"UserCounterService created. InstanceId: {InstanceId}");
    }

    public void Increment()
    {
        Count++;
        Console.WriteLine($"Instance {InstanceId} incremented to {Count}");
    }
}