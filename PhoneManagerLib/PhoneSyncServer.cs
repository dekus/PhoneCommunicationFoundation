using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    class PhoneSyncServer : IPhoneSyncServer
    {
        private readonly IPhoneSyncStorage _storage;

        public PhoneSyncServer(IPhoneSyncStorage storage)
        {
            this._storage = storage;
            this._storage.OnChangeNotify += storage_OnChangeNotify;
        }

        void storage_OnChangeNotify(object sender, EventArgs e)
        {
            this.ExecuteAction(this.GetCommand(e));
        }

        private IPhoneSyncCommand GetCommand(EventArgs e)
        {
            throw new NotImplementedException();
        }
        public ActionResult ExecuteAction(IPhoneSyncCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
