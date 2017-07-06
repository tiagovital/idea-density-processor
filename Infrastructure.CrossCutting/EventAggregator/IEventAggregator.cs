namespace Infrastructure.CrossCutting.EventAggregator
{
    public interface IEventAggregator
    {
        TEvent GetEvent<TEvent>() where TEvent : IEventBase, new();
    }
}