using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncodeUtil
{
    public class EventInfo : EventArgs
    {
        public enum EventType
        {
            OK,
            ERROR,
            CANCEL,
        }

        public EventInfo(EventType eventType, object eventTarget)
        {
            Type = eventType;
            Target = eventTarget;
        }

        public EventType Type { get; private set; }
        public object Target { get; private set; }
    }

}
