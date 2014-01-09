using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    interface IPhoneSyncClient 
    {
        bool SendCommand(IPhoneSyncCommand command);
        event EventHandler OnCommandExecutionComplete;
    }
}
