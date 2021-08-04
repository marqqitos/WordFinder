using System;
using System.Runtime.Serialization;

namespace WordFinder.Exceptions
{
    [Serializable]
    internal class MatrixSizeExceededException : Exception
    {
        public MatrixSizeExceededException()
        {
        }

        public MatrixSizeExceededException(string message) : base(message)
        {
        }

        public MatrixSizeExceededException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MatrixSizeExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}