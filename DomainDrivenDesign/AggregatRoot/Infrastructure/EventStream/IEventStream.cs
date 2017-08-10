using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AggregatRoot.Infrastructure.Event
{
    public interface IEventStream : IEnumerable<IDomainEventType>
    {
    }
}
