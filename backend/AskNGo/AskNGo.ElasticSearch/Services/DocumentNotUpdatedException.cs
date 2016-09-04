using System;
using System.Runtime.Serialization;

namespace AskNGo.ElasticSearch
{
    [Serializable]
    internal class DocumentNotUpdatedException : Exception
    {
        public DocumentNotUpdatedException()
        {
        }

        public DocumentNotUpdatedException(string message) : base(message)
        {
        }

        public DocumentNotUpdatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DocumentNotUpdatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}