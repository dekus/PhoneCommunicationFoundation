using System;
using System.IO;


namespace PhoneManagerLib
{
    public interface IPhoneSyncStorageFileInfo
    {
            FileAttributes FileAttribute { get; set; }
            long Length { get; }
            string Name { get; }

            bool IsDirectory();
    }
}
