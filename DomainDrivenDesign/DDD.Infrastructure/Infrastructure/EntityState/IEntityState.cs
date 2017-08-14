using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.Infrastructure.EntityState
{
    public interface IEntityState<TEntityState>
        where TEntityState : EntityState<TEntityState>
    {

    }
}
