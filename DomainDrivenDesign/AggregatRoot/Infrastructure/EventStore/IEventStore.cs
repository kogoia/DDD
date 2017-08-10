using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatRoot.Infrastructure.Event
{
    public interface IEventStore
    {
        IEnumerable<IDomainEventType> Events(int rootId);
    }

    public class FakeEventStore : IEventStore
    {
        public IEnumerable<IDomainEventType> Events(int rootId)
        {
            throw new NotImplementedException();
        }
    }
}
