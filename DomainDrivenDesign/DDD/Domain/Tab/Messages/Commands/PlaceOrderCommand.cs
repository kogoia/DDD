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
        public IEnumerator<IEvent<Tab>> GetEnumerator()
        {
            yield return new TabOpendEvent("Waiter 1");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
