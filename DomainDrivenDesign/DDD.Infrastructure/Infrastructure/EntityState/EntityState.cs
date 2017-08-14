namespace DDD.Infrastructure.Infrastructure.EntityState
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
