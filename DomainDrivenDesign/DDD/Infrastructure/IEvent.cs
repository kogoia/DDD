namespace DDD.Infrastructure
{
	public interface IEvent<TModel>
	{
		TModel Handle(TModel model);
		string Serialazed();
	}
}
