using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    interface IPhoneSyncClient 
    {
        void RegisterAction(string actionName, PhoneSyncActionBase action);
        ActionResult ExecuteAction(string actionName, object actionParam);
        bool SendCommand(IPhoneSyncCommand command);

    }
}
