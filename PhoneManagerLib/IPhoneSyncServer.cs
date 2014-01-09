using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    interface IPhoneSyncServer
    {
        void GetCommand();
        ActionResult ExecuteAction(IPhoneSyncCommand command);
    }
}
