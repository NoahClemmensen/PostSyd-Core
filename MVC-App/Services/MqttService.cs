using System.Buffers;
using System.Text;
using MQTT;
using MQTTnet;
using MVC_App.Interfaces;
using Newtonsoft.Json.Linq;

namespace MVC_App.Services;

public class MqttService : IMqttService
{
    private readonly ILogger<MqttService> _logger;
    private readonly BrokerConnection _connection;
    private readonly OcrMessageProcessor _messageProcessor;

    public MqttService(ILogger<MqttService> logger, OcrMessageProcessor messageProcessor)
    {
        _logger = logger;
        _messageProcessor = messageProcessor;
        
        _connection = BrokerConnection.Instance;
        _connection.SetConnectionDetails("10.130.56.30", "NoahsMac", 1883);

        _connection._client.ConnectedAsync += async _ =>
        {
            _logger.LogInformation("Connected to broker");
            await _connection.Subscribe("cam/ocr", HandleOcr);
        };

        _connection.Connect();
    }

    public async Task HandleOcr(string topic, ReadOnlySequence<byte> payload)
    {
        var message = Encoding.UTF8.GetString(payload.ToArray());
        _logger.LogInformation($"Received message: {message} on topic: {topic}");

        await _messageProcessor.ProcessMessage(message, this);
    }
    
    public async Task<MqttClientPublishResult> Publish(string topic, string message)
    {
        return await _connection.Publish(topic, message);
    }
}