using System.Buffers;
using System.Text;

namespace MQTT;

class Program
{
    static void Main(string[] args)
    {
        var conn = BrokerConnection.Instance;
        conn.SetConnectionDetails("10.130.56.30", "NoahsMac", 1883);

        conn._client.ConnectedAsync += async _ =>
        {
            Console.WriteLine("Connected to MQTT broker.");
            await conn.Subscribe("test/topic", (topic, payload) =>
            {
                var message = Encoding.UTF8.GetString(payload.ToArray());
                Console.WriteLine($"Received message: {message} on topic: {topic}");
                return Task.CompletedTask;
            });
        
            await conn.Subscribe("test/other", (topic, payload) =>
            {
                var message = Encoding.UTF8.GetString(payload.ToArray());
                Console.WriteLine($"Received message: {message} on topic: {topic}");
                return Task.CompletedTask;
            });
            
            await conn.Publish("test/topic", "Hello, TOPIC!");
            await conn.Publish("test/other", "Hello, OTHER!");
        };

        conn.Connect();
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}