namespace Infrastructure.CrossCutting.EventAggregator
{
    using System;
    using System.Collections.Generic;

    public class EventBase<T> : IEventBase
    {
        private readonly List<EventSubscription<T>> subscribers = new List<EventSubscription<T>>();

        public EventSubscription<T> Subscribe(Action<T> action)
        {
            var subscription = new EventSubscription<T>(action);

            this.subscribers.Add(subscription);

            return subscription;
        }

        public void Publish(T payload)
        {
            foreach (var sub in subscribers)
            {
                if (sub.ShouldNotify(payload))
                {
                    sub.Notify(payload);
                }
            }
        }
    }

    public interface IEventBase
    {
    }
}