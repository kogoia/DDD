using System;

namespace DDD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

			new NextState<Order>(
				new Order(),
				new OrderCreatedCommand()
			);
        }
    }
}
