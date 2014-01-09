using CashDepartment.MobileCollector.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    interface IPhoneSyncManager : IDisposable
    {
        
        void CreateCommand();
        ActionResult ExecuteAction(IPhoneSyncCommand command);
    }
}
