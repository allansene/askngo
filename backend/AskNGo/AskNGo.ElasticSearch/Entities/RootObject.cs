using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskNGo.ElasticSearch.Entities
{
    public class Shards
    {
        public int total { get; set; }
        public int successful { get; set; }
        public int failed { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public int PostTypeId { get; set; }
        public string ParentId { get; set; }
        public string CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public int OwnerUserId { get; set; }
        public string LastEditDate { get; set; }
        public string LastActivityDate { get; set; }
        public string CommentCount { get; set; }
        public string Relevance { get; set; }        
        public string AcceptedAnswerId { get; set; }
        public string OwnerUserDisplayName { get; set; }
        public string Title { get; set; }
        public string ClosedDate { get; set; }
        public string acceptedAnswerId
        {
            get { return AcceptedAnswerId; }
            set { AcceptedAnswerId = ""; }
        }
        public string ownerUserDisplayName
        {
            get { return OwnerUserDisplayName; }
            set { OwnerUserDisplayName = ""; }
        }
        public string lastEditDate
        {
            get { return LastEditDate; }
            set { LastEditDate = ""; }
        }
        public string parentId
        {
            get { return ParentId; }
            set { ParentId = "0"; }
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

    public class Source
    {
        public Post post { get; set; }
    }

    public class Hit
    {
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public double _score { get; set; }
        public Source _source { get; set; }
    }

    public class Hits
    {
        public int total { get; set; }
        public double max_score { get; set; }
        public List<Hit> hits { get; set; }
    }

    public class RootObject
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public Shards _shards { get; set; }
        public Hits hits { get; set; }
    }
}
