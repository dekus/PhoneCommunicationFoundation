using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagerLib
{
    public class ActionResult
    {
        public bool IsComplete { get; set; }
        public string Error { get; set; }
    }

    public class ActionResult<T> : ActionResult
    {
        public T Result { get; set; }
    }
}
