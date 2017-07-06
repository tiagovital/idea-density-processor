namespace Application.Events
{
    using Domain.Model;
    using Infrastructure.CrossCutting.EventAggregator;

    public class DocumentCreatingEvent : EventBase<Document>
    {
    }
}