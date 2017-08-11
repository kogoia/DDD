using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregatRoot.Infrastructure.EntityState
{
    public interface IEntityState<TEntityState>
        where TEntityState : EntityState<TEntityState>
    {

    }
    public abstract class EntityState<TEntityState> : IEntityState<TEntityState>
        where TEntityState : EntityState<TEntityState>
    {
        public abstract TEntityState FromJSON(string json);
    }


}
