using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatRoot.DataBase
{
    public class EventModel
    {
        public string AggregateRootId { get; set; }
        public string EventType { get; set; }
        public string MetaData { get; set; }
    }
}
