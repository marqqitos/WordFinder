using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WordFinder.Exceptions
{
    public class MatrixDifferentWordSizeException : Exception
    {
        public MatrixDifferentWordSizeException() { }

        public MatrixDifferentWordSizeException(string message) : base(message)
        {
        }

        public MatrixDifferentWordSizeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MatrixDifferentWordSizeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
