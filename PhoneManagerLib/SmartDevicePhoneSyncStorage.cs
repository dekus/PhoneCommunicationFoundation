using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    class SmartDevicePhoneSyncStorage : IPhoneSyncStorage
    {
        private readonly Microsoft.SmartDevice.Connectivity.Interface.IRemoteIsolatedStorageFile _storage;

        public SmartDevicePhoneSyncStorage(Microsoft.SmartDevice.Connectivity.Interface.IRemoteIsolatedStorageFile storage)
        {
            this._storage = storage;
        }
        public void CreateDirectory(string targetDeviceDirPath)
        {
            this._storage.CreateDirectory(targetDeviceDirPath);
        }
        public void DeleteDirectory(string targetDeviceDirPath)
        {
            this._storage.DeleteDirectory(targetDeviceDirPath);
        }
        public bool DirectoryExists(string targetDeviceDirPath)
        {
            return this._storage.DirectoryExists(targetDeviceDirPath);
        }

        public bool FileExists(string targetDeviceFilePath)
        {
            return this._storage.FileExists(targetDeviceFilePath);
        }

        public List<Microsoft.SmartDevice.Connectivity.Interface.IRemoteFileInfo> GetRemoteDirectoryListing(string searchPattern)
        {
            return this._storage.GetDirectoryListing(searchPattern);
        }
        public List<Microsoft.SmartDevice.Connectivity.Interface.IRemoteFileInfo> GetRemoteDirectoryListing()
        {
            return this._storage.GetDirectoryListing(string.Empty);
        }

        public List<string> GetDirectoryListing(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFilesListing(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public void ReceiveFile(string sourceDeviceFilePath, string targetDesktopFilePath, bool createNew)
        {
            this._storage.ReceiveFile(sourceDeviceFilePath, targetDesktopFilePath, createNew);
        }
        public void SendFile(string sourceDesktopFilePath, string targetDeviceFilePath, bool createNew)
        {
            this._storage.SendFile(sourceDesktopFilePath, targetDeviceFilePath, createNew);
        }
        public void CreateFile(string file, string data)
        {
            throw new NotImplementedException();
        }
        public void DeleteFile(string file)
        {
            throw new NotImplementedException();
        }

        public event EventHandler OnChangeNotify;   
    }
}
