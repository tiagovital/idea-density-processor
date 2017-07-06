using Application.Events;
using Domain.Model;
using Infrastructure.CrossCutting.EventAggregator;

namespace Application.Services.DocumentClassificationService
{
    public abstract class ClassificationStrategy
    {
        protected ClassificationStrategy(IEventAggregator evtAggregator)
        {
            this.Subscribe(evtAggregator);
        }

        private void Subscribe(IEventAggregator evtAggregator)
        {
            evtAggregator
                .GetEvent<DocumentCreatingEvent>()
                .Subscribe(Run);
        }

        protected abstract void Run(Document document);
    }
}