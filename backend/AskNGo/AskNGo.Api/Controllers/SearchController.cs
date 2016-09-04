using AskNGo.ElasticSearch;
using AskNGo.ElasticSearch.Services;
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
    public class SearchController : ApiController
    {
        // GET: api/Search
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Search/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Search
        public HttpResponseMessage Post(Post post)
        {
            var elasticService = new ElasticSearchHttpService();
            string result = elasticService.MoreLikeThisContent(post.Body, post.PostTypeId.ToString());
            return this.Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET: api/MyQuestions/5  1426
        [Route("api/MyQuestions/{OwnerUserId}")]
        [ActionName("MyQuestions")]
        [AcceptVerbs("GET")]
        public string MyQuestions(string OwnerUserId)
        {
            var elasticService = new ElasticSearchHttpService();
            var result = elasticService.QuestionsByUser(OwnerUserId);

            return result;
        }

    }
}
