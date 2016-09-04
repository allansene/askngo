using System;
using System.Runtime.Serialization;

namespace AskNGo.ElasticSearch
{
    [Serializable]
    internal class DocumentNotInsertedException : Exception
    {
        public DocumentNotInsertedException()
        {
        }

        public DocumentNotInsertedException(string message) : base(message)
        {
        }

        public DocumentNotInsertedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DocumentNotInsertedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}