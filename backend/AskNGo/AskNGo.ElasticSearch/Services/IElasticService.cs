using AskNGo.ElasticSearch.Entities;
using Nest;

namespace AskNGo.ElasticSearch
{
    public interface IElasticService
    {
        string GetClusterHealthStatus();
        CreateIndexDescriptor GetDescriptor();
        Document GetDocument(int id);
        void InsertDocument(Document document);
        void UpdateDocument(Document document);
        void DeleteDocument(int Id);
        string MoreLikeThisContent(string documentText, string PostTypeId);
     //   SearchResult<Document> SearchDocument(string query);
        void DeleteIndex();
        void CreateIndex();
    }
}