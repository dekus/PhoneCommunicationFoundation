using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    public class PhoneSyncCommand : IPhoneSyncCommand
    {
        public Guid Id { get; set; }
        public string ActionName { get; set; }
        public object Param { get; set; }

        public PhoneSyncCommand (string name, string param )
        {
            this.Id = Guid.NewGuid();
            this.ActionName = name;
            this.Param = (object) param;
        }
    }
}
