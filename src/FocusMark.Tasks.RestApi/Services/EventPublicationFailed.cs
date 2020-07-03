using System;
using System.Runtime.Serialization;

namespace FocusMark.Tasks.RestApi.Services
{
    [Serializable]
    internal class EventPublicationFailed : Exception
    {
        private string topicArn;
        private string userId;

        public EventPublicationFailed()
        {
        }

        public EventPublicationFailed(string message) : base(message)
        {
        }

        public EventPublicationFailed(string topicArn, string userId)
        {
            this.topicArn = topicArn;
            this.userId = userId;
        }

        public EventPublicationFailed(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EventPublicationFailed(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}