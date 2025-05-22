using MQTTnet;
using MVC_App.Interfaces;
using Newtonsoft.Json.Linq;

namespace MVC_App.Services;

public class OcrMessageProcessor(
    IDatabaseService databaseService,
    IPackageRoutingService routingService,
    ILogger<OcrMessageProcessor> logger)
{
    public async Task ProcessMessage(string message, IMqttService mqttService)
    {
        try
        {
            var data = JArray.Parse(message);
            if (!data.AsEnumerable().Any()) return;

            var value = data[0][1]?.ToObject<int>();
            var confidence = data[0][2]!.ToObject<double>();

            if (!(confidence > 0.5) || value == null) return;

            var package = await databaseService.GetPackageById((int)value);
            if (package == null) return;

            var department = await databaseService.GetDepartmentById(2);
            var destinationChute = await routingService.GetNextChute(package, department!);
            if (destinationChute == null) return;

            logger.LogInformation("Publishing to sorter/chute: {ChuteId}", destinationChute.ChuteId);
            await mqttService.Publish("sorter/chute", destinationChute.ChuteId.ToString());
        }
        catch (Exception e)
        {
            logger.LogError($"Error processing message: {e.Message}");
        }
    }
}