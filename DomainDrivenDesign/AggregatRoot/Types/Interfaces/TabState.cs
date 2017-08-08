using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatRoot.Types.Interfaces
{
    public class TabState
    {
        private string _name;
        public string Name { get { return _name; } }
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
