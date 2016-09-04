using AskNGo.ElasticSearch;
using AskNGo.ElasticSearch.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AskNGo.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DocumentController : ApiController
    {
        public object HttpService { get; private set; }

        // GET: api/Document
        public IEnumerable<string> Get()
        {
            return new string[] { "Inserir ID do documento depois da barra na URI", "Inserir ID do documento depois da barra na URI" };
        }

        // GET: api/Document/5
        public string Get(int id)
        { 
            var elasticService = new ElasticSearchHttpService();
            var result = elasticService.AsnwersForQuestion(id);

            return result;
        }

        public HttpResponseMessage Post(Document document)
        {
            var elasticService = new ElasticSearchHttpService();
            string result = elasticService.InsertDocument(document);
            return this.Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE: api/Document/5
        public HttpResponseMessage Delete(int id)
        {
            var elasticService = new ElasticSearchHttpService();
            elasticService.DeleteDocument(id);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
