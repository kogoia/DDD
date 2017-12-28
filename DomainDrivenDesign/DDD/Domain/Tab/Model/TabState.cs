

namespace DDD.Domain.Tab.Model
{
    public class TabState 
    {
        public int Id { get; }
        public string Number { get;  protected set; }
        public string Waiter { get;  protected set; }
        public decimal Price { get;  protected set; }
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
