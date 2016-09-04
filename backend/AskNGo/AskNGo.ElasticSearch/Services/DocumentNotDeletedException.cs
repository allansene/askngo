using System;
using System.Runtime.Serialization;

namespace AskNGo.ElasticSearch
{
    [Serializable]
    internal class DocumentNotDeletedException : Exception
    {
        public DocumentNotDeletedException()
        {
        }

        public DocumentNotDeletedException(string message) : base(message)
        {
        }

        public DocumentNotDeletedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DocumentNotDeletedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}