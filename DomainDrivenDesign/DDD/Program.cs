using System;
using DDD.Domain.Order;
using DDD.Domain.Tab;
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
                new Tab(new DefaultTab(127, "VIP")), 
                new IEvent<Tab>[] { }
            );
        }
    }
}
