using System;
using System.Collections.Generic;
using System.Text;

namespace DDD
{
	public class OrderReservedEvent : IEvent<Order>
	{
		public Order Handle(Order model)
		{
			throw new NotImplementedException();
		}

		public string Serialazed()
		{
			throw new NotImplementedException();
		}
	}
}
