using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace IoTHubCommunicatorPrototype
{
  class Program
  {
    private const string DeviceConnectionString = "";

    static async Task Main(string[] args)
    {
      await CommunicateToIoTHubAsync();
    }

    #region Communicate to IoTHub

    private static async Task CommunicateToIoTHubAsync()
    {
      var deviceClient = DeviceClient.CreateFromConnectionString(DeviceConnectionString);

      while (true)
      {
        var msgModel = new
        {
          msg = "Connected to IoTHub..."
        };
        var messageString = JsonConvert.SerializeObject(msgModel);
        var message = new Message(Encoding.ASCII.GetBytes(messageString));

        await deviceClient.SendEventAsync(message);
        Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);

        await Task.Delay(1000);
      }
    }

    #endregion
  }
}
