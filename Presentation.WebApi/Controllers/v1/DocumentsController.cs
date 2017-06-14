namespace Presentation.API.Controllers.v1
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Application.Services;
    using Models;

    [RoutePrefix("v1/documents")]
    public class DocumentsController : ApiController
    {
        #region Private Members

        private readonly IDocumentService service;

        #endregion Private Members

        #region Ctors

        public DocumentsController(IDocumentService service)
        {
            //
            this.service = service;
        }

        #endregion Ctors

        #region Action Methods

        [HttpGet, Route(""), ResponseType(typeof(IEnumerable<SearchDocumentModel>))]
        public async Task<IHttpActionResult> GetAll(int page, int pageSize)
        {
            var documents = await this.service.GetAll(page, pageSize).ConfigureAwait(false);

            var model = documents.Select(d => new SearchDocumentModel
            {
                DocumentName = d.Title,
                DocumentCreatedAt = d.CreatedAt,
                Author = d.Author
            });

            return this.Ok(model);
        }

        #endregion Action Methods
    }
}