using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    public interface IPhoneSyncServer
    {
        IPhoneSyncCommand GetCommand(StorageChangeEventArgs e);
        ActionResult ExecuteAction(IPhoneSyncCommand command);
    }
}
