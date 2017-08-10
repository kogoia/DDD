namespace AggregatRoot.Infrastructure.Event
{
    public interface IApplicable<TEntity>
    {
        AppliedEventResult<TEntity> Apply();
    }
}
