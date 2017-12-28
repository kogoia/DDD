using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DDD
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
