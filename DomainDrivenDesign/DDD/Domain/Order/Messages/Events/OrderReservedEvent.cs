using System;
using DDD.Infrastructure;

namespace DDD.Domain.Order.Messages.Events
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
