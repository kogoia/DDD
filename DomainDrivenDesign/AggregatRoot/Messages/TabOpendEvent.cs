using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatRoot.Messages
{
    public interface IEvent { }
    public class TabOpendEvent : IEvent
    {
    }

    public class TabClosedEvent : IEvent
    {
    }
}
