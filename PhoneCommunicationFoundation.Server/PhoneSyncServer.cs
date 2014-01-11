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
        }

        public IPhoneSyncCommand GetCommand(StorageChangeEventArgs e)
        {
            return new PhoneSyncCommand().XmlDeserialize<IPhoneSyncCommand>(this._storage.ReadFile(e.NewFiles[0]));
        }
        public ActionResult ExecuteAction(IPhoneSyncCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
