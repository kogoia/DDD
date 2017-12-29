using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Tab.Messages.Events;
using DDD.Infrastructure;

namespace DDD.Domain.Tab.Messages.Commands
{
    public class PlaceOrderCommand : ICommand<Tab>
    {
        private readonly string _tabName;
        private readonly string _waiterName;

        public PlaceOrderCommand(string tabName, string waiterName)
        {
            _tabName = tabName;
            _waiterName = waiterName;
        }
        public IEnumerator<IEvent<Tab>> GetEnumerator()
        {
            yield return new TabCreatedEvent(127, _tabName);
            yield return new TabOpendEvent(_waiterName);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
