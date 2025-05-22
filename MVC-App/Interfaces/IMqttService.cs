using System.Buffers;
using MQTTnet;

namespace MVC_App.Interfaces;

public interface IMqttService
{
    Task HandleOcr(string topic, ReadOnlySequence<byte> payload);
    Task<MqttClientPublishResult> Publish(string topic, string message);
}