using System;
using PhoneManagerLib;


namespace ConsoleApplication1
{

    internal class Program
    {
        public static Microsoft.SmartDevice.MultiTargeting.Connectivity.ConnectableDevice CDevice;
        public static void Main()
        {
            var newWatcher = new PhoneManager();
            newWatcher.RaiseDeviceConnectedEvent += newWatcher_RaiseDeviceConnectedEvent;
            newWatcher.RaiseDeviceDisconnectedEvent += newWatcher_RaiseDeviceDisconnectedEvent;
            Console.ReadLine();
        }

        static void newWatcher_RaiseDeviceDisconnectedEvent(object sender, PhoneManager.DeviceEventArgs e)
        {
            CDevice = null;
        }

        static void newWatcher_RaiseDeviceConnectedEvent(object sender, PhoneManager.DeviceEventArgs e)
        {
            Console.WriteLine(e.ConnectedDevice.Id);
            Console.WriteLine(e.ConnectedDevice.Name);
            var device = e.ConnectedDevice.Connect();
            var applications = device.GetInstalledApplications();
            foreach (var remoteApplication in applications)
            {
                var store = remoteApplication.GetIsolatedStore();
            }
        }
    }
}



 

