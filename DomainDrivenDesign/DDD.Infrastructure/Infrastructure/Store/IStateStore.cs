using DDD.Infrastructure.Infrastructure.EntityState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.Infrastructure.Store
{
    public interface IStateStore
        
    {
    }

    public class StateStore<TEntityType>
        where TEntityType : EntityState<TEntityType>
    {
        public StateStore()
        {
            
        }

        public EntityState<TEntityType> State()
        {
            return null;
        }
    }
}
