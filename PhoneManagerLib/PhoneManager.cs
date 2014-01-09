using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CashDepartment.MobileCollector.DomainModel.Entities;
using Microsoft.SmartDevice.Connectivity;
using Microsoft.SmartDevice.Connectivity.Interface;
using Microsoft.SmartDevice.MultiTargeting.Connectivity;

namespace PhoneManagerLib
{
    public class PhoneManager
    {

        #region DeviceEventArgs
        public class DeviceEventArgs
        {
            public DeviceEventArgs(ConnectableDevice device)
            {
                _connectedDevice = device;
            }

            private readonly ConnectableDevice _connectedDevice;

            public ConnectableDevice ConnectedDevice
            {
                get { return _connectedDevice; }
            }
        }
        #endregion

        #region Events
        public delegate void DeviceConnectEventHandler(object sender, DeviceEventArgs a);
        public delegate void DeviceDisconnectEventHandler(object sender, DeviceEventArgs a);

        public event EventHandler<DeviceEventArgs> RaiseDeviceConnectedEvent;
        public event EventHandler<DeviceEventArgs> RaiseDeviceDisconnectedEvent;

        protected virtual void OnRaiseDeviceDisconnectedEvent(DeviceEventArgs e)
        {
            EventHandler<DeviceEventArgs> handler = RaiseDeviceDisconnectedEvent;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnRaiseDeviceConnectedEvent(DeviceEventArgs e)
        {
            EventHandler<DeviceEventArgs> handler = RaiseDeviceConnectedEvent;
            if (handler != null) handler(this, e);
        }
        #endregion

        private IList<ManagementEventWatcher> _watchers;

        private IList<ConnectableDevice> _devices;

        public IList<ConnectableDevice> Devices
        {
            get
            {
                return _devices;
            }
        }

        public PhoneManager()
        {
            SetupWatchers();
        }

        private void SetupWatchers()
        {
            this.GetManagementEventWatcher(
                new WqlEventQuery
                {
                    EventClassName = "__InstanceCreationEvent",
                    WithinInterval = new TimeSpan(0, 0, 1),
                    Condition = @"TargetInstance ISA 'Win32_USBControllerDevice' "
                },
                WatcherDeviceConnected
                );
            this.GetManagementEventWatcher(
                new WqlEventQuery
                {
                    EventClassName = "__InstanceDeletionEvent",
                    WithinInterval = new TimeSpan(0, 0, 1),
                    Condition = @"TargetInstance ISA 'Win32_USBControllerDevice' "
                },
                WatcherDeviceDisconnected
                );
        }

        private void GetManagementEventWatcher(WqlEventQuery q, EventArrivedEventHandler EventArrived)
        {
            try
            {
                var w = new ManagementEventWatcher(new ManagementScope(@"\\localhost\root\cimv2"), q);

                w.EventArrived += EventArrived;
                w.Start();
                _watchers.Add(w);
            }
            catch(Exception e)
            {
                //some logging
            }
        }

        private void EnumDevices()
        {
            var MTC = new MultiTargetingConnectivity(1033);
            this._devices = MTC.GetConnectableDevices();
        }

        private void WatcherDeviceConnected(object sender, EventArrivedEventArgs e)
        {
            this.EnumDevices();
            this.OnRaiseDeviceConnectedEvent(new DeviceEventArgs(this.Devices.First(d => d.IsEmulator() == false)));
        }

        private void WatcherDeviceDisconnected(object sender, EventArrivedEventArgs e)
        {
            this.EnumDevices();
            this.OnRaiseDeviceDisconnectedEvent(new DeviceEventArgs(this.Devices.First(d => d.IsEmulator() == false)));
        }
    }
}
