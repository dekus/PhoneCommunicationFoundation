using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    public class PhoneSyncClient : IPhoneSyncClient
    {
        private readonly IPhoneSyncStorage _storage;

        public PhoneSyncClient (IPhoneSyncStorage storage)
        {
            this._storage = storage;
            this._storage.OnChangeNotify += _storage_OnChangeNotify;
        }

        void _storage_OnChangeNotify(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public bool SendCommand(IPhoneSyncCommand command)
        {
            throw new NotImplementedException();
        }
        public event EventHandler OnCommandExecutionComplete;
    }
}
