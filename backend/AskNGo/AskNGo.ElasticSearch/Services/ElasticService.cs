using AskNGo.ElasticSearch.Entities;
using Nest;
using System;
using System.Collections.Generic;

namespace AskNGo.ElasticSearch
{
    public class ElasticService : IElasticService
    {
        private const string DOCUMENT_INDEX_NAME = "testewagner";
        private const string ELASTIC_SERVER_URI = "http://elastic.allansene.me/";//"http://localhost:9200/"; //

        private ElasticClient _elasticClient { get; set; }

        public ElasticService()
        {

            _elasticClient = new ElasticClient(new Uri(ELASTIC_SERVER_URI));

            var node = new Uri(ELASTIC_SERVER_URI);
            var settings = new ConnectionSettings(node).BasicAuthentication("admin", "wBnewR82Ec")
            // lower case index name
            .DefaultIndex(DOCUMENT_INDEX_NAME);

            _elasticClient = new ElasticClient(settings);

            if (!_elasticClient.IndexExists(DOCUMENT_INDEX_NAME).Exists)
            {
                _elasticClient.CreateIndex(DOCUMENT_INDEX_NAME);
            }

            //this.MappingDefault();
        }

        public string GetClusterHealthStatus()
        {
            var res = _elasticClient.ClusterHealth();
            return res.Status;
        }

        public CreateIndexDescriptor GetDescriptor()
        {
            var descriptor = new CreateIndexDescriptor(DOCUMENT_INDEX_NAME)
            .Mappings(ms => ms
                .Map<Document>(m => m.AutoMap())
            );

            return descriptor;
        }

        public Post GetDocument(int id)
        {
            //_elasticClient.Get<Post>()
            var response = _elasticClient.Get<Post>(id, idx => idx.Index(DOCUMENT_INDEX_NAME));
            var document = response.Source;
            return document;
        }

        public void InsertDocument(Post document)
        {
            try
            {
                // var response = _elasticClient.Index(document, idx => idx.Index(DOCUMENT_INDEX_NAME));
                var response = _elasticClient.Index(document, i => i
         .Index(DOCUMENT_INDEX_NAME)
         .Type(typeof(Post))
         .Id(document.Id)
         .Refresh());
                if (!response.Created)
                {
                    throw new DocumentNotInsertedException();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateDocument(Post document)
        {
            try
            {
                var response = _elasticClient.Update<Post>(
                    new DocumentPath<Post>(document.Id), u =>
                       u.Index(DOCUMENT_INDEX_NAME).Doc(document));
                if (!response.IsValid)
                {
                    throw new DocumentNotUpdatedException();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteDocument(int Id)
        {
            try
            {
                var response = _elasticClient.Delete<Post>(Id);
                if (!response.IsValid)
                {
                    throw new DocumentNotDeletedException();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Document SearchDocument(string fieldName, string value)
        {
            var result = _elasticClient.Search<Post>(x => x
            .Index(DOCUMENT_INDEX_NAME)
            .Type(typeof(Post))
                .Query(q => q.Term(c => c.Field(j => j.Id == 1))));

            return new Document();
        }

        public SearchResult<Post> MoreLikeThisContent(string documentText)
        {

            var result = _elasticClient.Search<Post>(x => x
                .Query(q => q
                    .MoreLikeThis(mlt => mlt
                        .Like(l => l
                           .Text(documentText))
                        .Fields(f => f
                        .Fields(new string[] { "title", "body" })
                        // .Fields("post.Body", "post.Title")
                        )
                        .MaxQueryTerms(12)
                        .MinDocumentFrequency(1)
                        .MinTermFrequency(1)
                    )
                 )//.Fields(new string[] { "post.Title", "post.Body" })
              );

            /* foreach(var p in result.Fields)
             {
                 p.
             }
             List<Post> posts = 
             from q in result.Fields
             select new 
             {

             }*/

            //var list = result.HitsMetaData.Hits.ConvertAll<Post>(c => c.Fields, );
            //string ret  = System.Text.Encoding.UTF8.GetString(result.ApiCall.RequestBodyInBytes);
            return new SearchResult<Post>
            {
                Total = (int)result.Total,
                Results = result.Documents,
                ElapsedMilliseconds = result.Took
            };
        }


        /// <summary>
        /// PRIVATE METHODS
        /// </summary>

        //private MoreLikeThisQuery GetMoreLikeThisQuery(Field field, Document document)

        private MoreLikeThisQuery GetMoreLikeThisQuery(Field field, string documentText)
        {
            var query = new MoreLikeThisQuery
            {
                //Boost = 1.1,
                Fields = field,
                Like = new List<Like>
                {
                    //new LikeDocument<Document>(document.Id),
                    documentText
                },
                MinimumShouldMatch = 1,
                StopWords = new[] { "and", "the", "as", "a" }
            };

            return query;
        }

        public void DeleteIndex()
        {
            if (_elasticClient.IndexExists(DOCUMENT_INDEX_NAME).Exists)
            {
                _elasticClient.DeleteIndex(DOCUMENT_INDEX_NAME);
            }
        }

        public void CreateIndex()
        {
            if (!_elasticClient.IndexExists(DOCUMENT_INDEX_NAME).Exists)
            {
                _elasticClient.CreateIndex(DOCUMENT_INDEX_NAME);
            }
        }

        private void MappingDefault()
        {
            var settings = new ConnectionSettings()
                .MapDefaultTypeIndices(m => m.Add(typeof(Document), DOCUMENT_INDEX_NAME));

            var resolver = new IndexNameResolver(settings);
            var index = resolver.Resolve<Document>();
        }

        Document IElasticService.GetDocument(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertDocument(Document document)
        {
            throw new NotImplementedException();
        }

        public void UpdateDocument(Document document)
        {
            throw new NotImplementedException();
        }

        public string MoreLikeThisContent(string documentText, string PostTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
