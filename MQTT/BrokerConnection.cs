using System.Buffers;
using MQTTnet;

namespace MQTT;

public class BrokerConnection
{
    private string Host { get; set; }
    private string ClientId { get; set; }
    private int Port { get; set; }
    
    private BrokerConnection()
    {
        _client = _clientFactory.CreateMqttClient();
    }
    
    private readonly MqttClientFactory _clientFactory = new MqttClientFactory();
    internal readonly IMqttClient _client;
    
    private static BrokerConnection? _instance;
    public static BrokerConnection Instance => _instance ??= new BrokerConnection();
    
    private readonly Dictionary<string, Func<string, ReadOnlySequence<byte>, Task>> _messageHandlers = new();

    private async Task OnMessageReceived(MqttApplicationMessageReceivedEventArgs e)
    {
        var message = e.ApplicationMessage;
        var payload = message.Payload;
        var topic = message.Topic;
        
        await _messageHandlers[topic].Invoke(topic, payload);
    }

    internal async Task<MqttClientConnectResult?> Connect()
    {
        if (_client.IsConnected) return null;
        
        var mqttClientOptions = new MqttClientOptionsBuilder()
            .WithClientId(ClientId)
            .WithTcpServer(Host, Port)
            .Build();

        var result = await _client.ConnectAsync(mqttClientOptions, CancellationToken.None);
        _client.ApplicationMessageReceivedAsync += OnMessageReceived;
        return result;
    }
    
    public void SetConnectionDetails(string host, string clientId, int port)
    {
        Host = host;
        ClientId = clientId;
        Port = port;
    }

    public async Task Disconnect()
    {
        var mqttDisconnectionOptions = _clientFactory.CreateClientDisconnectOptionsBuilder().Build();
        await _client.DisconnectAsync(mqttDisconnectionOptions, CancellationToken.None);
    }

    public async Task<MqttClientPublishResult> Publish(string topic, string payload)
    {
        if (!_client.IsConnected)
        {
            await Connect();
        }
        
        var mqttMessage = _clientFactory.CreateApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(payload)
            .Build();

        return await _client.PublishAsync(mqttMessage);
    }
    
    public async Task<MqttClientSubscribeResult?> Subscribe(string topic, Func<string, ReadOnlySequence<byte>, Task> handler)
    {
        if (!_client.IsConnected)
        {
            await Connect();
        }
        
        var mqttSubscribeOptions = _clientFactory.CreateSubscribeOptionsBuilder()
            .WithTopicFilter(topic)
            .Build();

        var result = await _client.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
        _messageHandlers[topic] = handler;
        
        return result;
    }
}