namespace Presentation.Api.Controllers.v1
{
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Application.Dto;
    using Application.Services.DocumentClassificationService;

    [RoutePrefix("v1/wordClassification")]
    public class WordClassificationController : ApiController
    {
        #region Private Members

        private readonly IDocumentClassificationService service;

        #endregion Private Members

        #region Ctors

        public WordClassificationController(IDocumentClassificationService service)
        {
            //
            this.service = service;
        }

        #endregion Ctors

        #region Actions

        [HttpGet, Route(""), ResponseType(typeof(WordDto))]
        [Swashbuckle.Swagger.Annotations.SwaggerResponse(HttpStatusCode.OK)]
        public async Task<IHttpActionResult> Get(string word)
        {
            var result = await this.service.Classificate(word).ConfigureAwait(false);

            return this.Ok(result);
        }

        #endregion Actions
    }
}