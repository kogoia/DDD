using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatRoot.Messages
{
    public interface IDomainEvent { }
    public class TabOpendEvent : IDomainEvent
    {
    }

    public class TabClosedEvent : IDomainEvent
    {
    }
}
