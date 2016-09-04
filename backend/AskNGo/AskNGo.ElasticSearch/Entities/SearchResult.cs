using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskNGo.ElasticSearch.Entities
{
    public class SearchResult<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Results { get; set; }
        public int ElapsedMilliseconds { get; set; }
    }
}
