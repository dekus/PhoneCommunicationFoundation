using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    public class StorageChangeEventArgs : EventArgs
    {
        public List<string> NewFiles { get; set; }
    }
}
