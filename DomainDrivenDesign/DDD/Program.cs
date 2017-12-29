using System;
using DDD.Domain.Order;
using DDD.Domain.Order.Messages.Commands;
using DDD.Domain.Tab;
using DDD.Domain.Tab.Messages.Commands;
using DDD.Domain.Tab.Messages.Events;
using DDD.Infrastructure;

namespace DDD
{
    class Program
    {
        static void Main(string[] args)
        {
            new NextState<Order>(
                new Order(),
                new OrderCreatedCommand()
            );

            new NextState<Tab>(
                new TabCreatedEvent(127, "VIP Table"),
                new PlaceOrderCommand("VIP Table", "Waiter 1")
            );
        }
    }
}
