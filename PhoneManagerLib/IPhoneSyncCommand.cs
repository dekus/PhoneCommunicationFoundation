using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    interface IPhoneSyncCommand
    {
        Guid Id { get; set; }
        string ActionName { get; set; }
        object Param { get; set; }
    }
}
