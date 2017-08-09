namespace AggregatRoot.Domain.Tab
{
    public class TabState
    {
        private string _name;
        public string Name => _name;

        public TabState(string name)
        {
            _name = name;
        }

        public TabState WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}
