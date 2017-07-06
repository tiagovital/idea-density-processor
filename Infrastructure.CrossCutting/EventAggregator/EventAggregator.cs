using System;
using System.Collections.Concurrent;

namespace Infrastructure.CrossCutting.EventAggregator
{
    public class EventAggregator : IEventAggregator
    {
        private readonly ConcurrentDictionary<Type, IEventBase> events = new ConcurrentDictionary<Type, IEventBase>();

        public TEvent GetEvent<TEvent>()
            where TEvent : IEventBase, new()
        {
            var evtType = typeof(TEvent);

            return (TEvent)this.events.GetOrAdd(evtType, new TEvent());
        }
    }
}