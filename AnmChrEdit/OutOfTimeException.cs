using System;
using System.Runtime.Serialization;

namespace AnmChrEdit
{
    [Serializable]
    internal class OutOfTimeException : Exception
    {
        public OutOfTimeException()
        {
        }

        public OutOfTimeException(string message) : base(message)
        {
        }

        public OutOfTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OutOfTimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}