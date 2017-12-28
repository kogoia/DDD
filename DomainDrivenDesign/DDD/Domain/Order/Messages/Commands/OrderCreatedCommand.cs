using System.Collections;
using System.Collections.Generic;
using DDD.Domain.Order.Messages.Events;
using DDD.Infrastructure;

namespace DDD.Domain.Order.Messages.Commands
{
	public class OrderCreatedCommand : ICommand<Order>
	{
		public IEnumerator<IEvent<Order>> GetEnumerator()
		{
			yield return new OrderReservedEvent();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
