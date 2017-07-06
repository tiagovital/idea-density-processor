namespace Infrastructure.CrossCutting.EventAggregator
{
    using System;

    public class EventSubscription<TPayload>
    {
        private Action<TPayload> action;
        private Predicate<TPayload> filter = new Predicate<TPayload>((p) => true);

        public EventSubscription(Action<TPayload> action)

        {
            this.action = action;
        }

        public void Where(Predicate<TPayload> filter)
        {
            this.filter = filter;
        }

        public void Notify(TPayload payload)
        {
            this.action.Invoke(payload);
        }

        public bool ShouldNotify(TPayload payload)
        {
            return this.filter.Invoke(payload);
        }

        public static EventSubscription<TPayload> From(Action<TPayload> action)
        {
            return new EventSubscription<TPayload>(action);
        }
    }
}