using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatRoot.Infrastructure.Entity
{
    public interface IIdentity
    {
        string Id();
    }

    public abstract class Identity
    {
        public Identity()
        {
            
        }
    }
}
