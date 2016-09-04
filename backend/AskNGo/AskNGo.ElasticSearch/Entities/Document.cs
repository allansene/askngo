using Nest;

namespace AskNGo.ElasticSearch
{
    public class Post
    {
        public int Id { get; set; }
        public int PostTypeId { get; set; }
        public string AcceptedAnswerId { get; set; }
        public string ParentID { get; set; }
        public string CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public string OwnerUserId { get; set; }
        public string OwnerUserDisplayName { get; set; }
        public string ParentId { get; set; }
        public string Title { get; set; }
        public string ClosedDate { get; set; }
        public string Relevance { get; set; }
        public string CommentCount { get; set; }
        public string LastActivityDate { get; set; }
        public string LastEditDate { get; set; }

        public string lastEditDate
        {
            get { return LastEditDate; }
            set { LastEditDate = ""; }
        }
        public string lastActivityDate
        {
            get { return LastActivityDate; }
            set { LastActivityDate = ""; }
        }
        public string commentCount
        {
            get { return CommentCount; }
            set { CommentCount = ""; }
        }
        public string relevance
        {
            get { return Relevance; }
            set { Relevance = ""; }
        }

    }

    public class Document
    {
        public Post post { get; set; }
    }
}