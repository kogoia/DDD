namespace AggregatRoot.Infrastructure.Event
{
    public interface IApplicable<out TEntity>
    {
        IAppliedEventResult<TEntity> Appled();
    }
}
