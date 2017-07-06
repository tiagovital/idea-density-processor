namespace Application.Services.DocumentClassificationService
{
    using System.Threading.Tasks;
    using Domain.Model;
    using Infrastructure.CrossCutting.EventAggregator;

    public class SyncClassificationStrategy : ClassificationStrategy
    {
        private readonly IDocumentClassificationService classificationService;

        public SyncClassificationStrategy(
            IEventAggregator evtAggregator,
            IDocumentClassificationService classificationService)
            : base(evtAggregator)
        {
            this.classificationService = classificationService;
        }

        protected override void Run(Document document)
        {
            Task
                .Run(async () =>
                {
                    await this.classificationService.Classificate(document).ConfigureAwait(false);
                })
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }
    }
}