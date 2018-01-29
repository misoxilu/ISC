using ISC.Global.Common.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISC.Global.Common
{
    public class EventHandlerArgs : EventArgs
    {
        public EventName Name { get; set; }
        public object Value { get; set; }
        public EventHandlerArgs(EventName name, object value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
