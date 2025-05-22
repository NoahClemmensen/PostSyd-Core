using MVC_App.Interfaces;

namespace MVC_App.Services;

public class MqttHostedService : IHostedService
{
    private readonly IMqttService _mqttService;
    
    public MqttHostedService(IMqttService mqttService)
    {
        _mqttService = mqttService;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}