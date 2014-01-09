using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    public interface IPhoneSyncStorage
    {
   
        void CreateDirectory(string targetDeviceDirPath);
        void DeleteDirectory(string targetDeviceDirPath);
        bool DirectoryExists(string targetDeviceDirPath);
        bool FileExists(string targetDeviceFilePath);
        List<IPhoneSyncStorageFileInfo> GetDirectoryListing(string searchPattern);
        List<IPhoneSyncStorageFileInfo> GetDirectoryListing();
        void ReceiveFile(string sourceDeviceFilePath, string targetDesktopFilePath, bool createNew);
        void SendFile(string sourceDesktopFilePath, string targetDeviceFilePath, bool createNew);
        void CreateFile(string file, string data);
        void DeleteFile(string file);

        event EventHandler OnChangeNotify;
    }
}
