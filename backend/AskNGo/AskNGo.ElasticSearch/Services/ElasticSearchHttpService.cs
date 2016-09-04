using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AskNGo.ElasticSearch.Entities;
using Nest;

namespace AskNGo.ElasticSearch.Services
{
    public class ElasticSearchHttpService
    {
        private const string DOCUMENT_INDEX_NAME = "testewagner";
        private const string ELASTIC_SERVER_URI = "http://elastic.allansene.me/";

        public string MoreLikeThisContent(string documentText, string PostTypeId)
        {
            string json = "{ \"query\": { \"filtered\": { \"query\": { \"more_like_this\" : { \"fields\" :[\"post.Body\", \"post.Title\"], \"like_text\": \"" + documentText + "\", \"min_doc_freq\": 1, \"min_term_freq\" : 1, \"max_query_terms\" : 12 } }, \"filter\": { \"query\": { \"match\": { \"post.PostTypeId\": { \"query\": " + PostTypeId + " } } } } }}}";
            return HttpService.HttpPost(json, ELASTIC_SERVER_URI + "teste4/post/_search");
        }

        void CreateIndex()
        {
            throw new NotImplementedException();
        }

        public void DeleteDocument(int Id)
        {
            HttpService.HttpDelete(ELASTIC_SERVER_URI, "/teste4/post/" + Id.ToString());
        }

        public string AsnwersForQuestion(int ParentId)
        {
            string json = "{ \"query\": { \"match\":{ \"post.ParentId\": { \"query\": " + ParentId.ToString() + " } } } }";
            return HttpService.HttpPost(json, ELASTIC_SERVER_URI + "teste4/post/_search");
        }

        public string QuestionsByUser(string OwnerUserId)
        {
            string json = "{ \"query\": { \"match\":{ \"post.OwnerUserId\": { \"query\": " + OwnerUserId + " } } } }";
            return HttpService.HttpPost(json, ELASTIC_SERVER_URI + "teste4/post/_search");
        }

        string GetClusterHealthStatus()
        {
            throw new NotImplementedException();
        }

        CreateIndexDescriptor GetDescriptor()
        {
            throw new NotImplementedException();
        }

        public string GetDocument(int id)
        {
            string json = "{ \"query\": { \"match\":{ \"post.Id\": { \"query\": " + id.ToString() + "} } } }";
            return HttpService.HttpPost(json, ELASTIC_SERVER_URI + "teste4/post/_search");
        }

        public string InsertDocument(Document document)
        {
            // string json = "{\"index\":{ \"_index\":\"teste4\",\"_type\":\"post\",\"_id\":" + document.post.Id + "}}" + Environment.NewLine + "{\"post\":" + Newtonsoft.Json.JsonConvert.SerializeObject(document) + "}]";
            return _InsertDocument(document, true);
        }

        private string _InsertDocument(Document document, bool insert)
        {
             if (insert) {
                document.post.Id = new Random(DateTime.Now.Second).Next(200000, 400000);
                //document.post.CreationDate = DateTime.Now.ToString();
             //   document.post.ClosedDate = DateTime.Now.ToString();
            }
            // string json = "{\"index\":{ \"_index\":\"teste4\",\"_type\":\"post\",\"_id\":" + document.post.Id + "}}" + Environment.NewLine + "{\"post\":" + Newtonsoft.Json.JsonConvert.SerializeObject(document) + "}]";
            return HttpService.HttpPut<Document>(document, ELASTIC_SERVER_URI + @"/teste4/post/" + document.post.Id);
        }

        public void UpdateDocument(int id, int favorite)
        {
            string docjson = GetDocument(id);
            RootObject data = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(docjson);
            Document myDoc = new Document();
            myDoc.post.Id = data.hits.hits[0]._source.post.Id;
            myDoc.post.PostTypeId = data.hits.hits[0]._source.post.PostTypeId;
            myDoc.post.ParentId = data.hits.hits[0]._source.post.ParentId;
            myDoc.post.CreationDate = data.hits.hits[0]._source.post.CreationDate;
            myDoc.post.Score = data.hits.hits[0]._source.post.Score;
            myDoc.post.Body = data.hits.hits[0]._source.post.Body;
            myDoc.post.OwnerUserId = data.hits.hits[0]._source.post.OwnerUserId.ToString();
            myDoc.post.LastEditDate = data.hits.hits[0]._source.post.LastEditDate;
            myDoc.post.LastActivityDate = data.hits.hits[0]._source.post.LastActivityDate;
            myDoc.post.CommentCount = data.hits.hits[0]._source.post.CommentCount;
            myDoc.post.AcceptedAnswerId = data.hits.hits[0]._source.post.AcceptedAnswerId;
            myDoc.post.OwnerUserDisplayName = data.hits.hits[0]._source.post.OwnerUserDisplayName;
            myDoc.post.Title = data.hits.hits[0]._source.post.Title;
            myDoc.post.ClosedDate = data.hits.hits[0]._source.post.ClosedDate;
            myDoc.post.LastEditDate = data.hits.hits[0]._source.post.LastEditDate;
            //
            string oldRelevance = data.hits.hits[0]._source.post.Relevance;
            List<int> relevance = Newtonsoft.Json.JsonConvert.DeserializeObject<List<int>>(oldRelevance);
            relevance.Add(favorite);
            myDoc.post.Relevance = Newtonsoft.Json.JsonConvert.SerializeObject(relevance); ;
            //
            //InsertDocument(myDoc);
            _InsertDocument(myDoc, false);
        }
    }
}
