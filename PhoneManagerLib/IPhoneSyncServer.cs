using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    interface IPhoneSyncServer
    {
        IPhoneSyncCommand GetCommand();
        void RegisterAction(string actionName, PhoneSyncActionBase action);
        ActionResult ExecuteAction(IPhoneSyncCommand command);
    }
}
