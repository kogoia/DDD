using System.Globalization;

namespace AggregatRoot.Domain.Tab
{
    public class TabState
    {
        public int Id { get; }
        public string Number { get; private set; }
        public string Waiter { get; private set; }
        public decimal Price { get; private set; }
        public TabState(int id)
        {
            Id = id;
        }

        public TabState WithNumber(string number)
        {
            Number = number;
            return this;
        }

        public TabState WithwWiter(string waiter)
        {
            Waiter = waiter;
            return this;
        }

        public TabState WithPrice(decimal price)
        {
            Price = price;
            return this;
        }
    }
}
