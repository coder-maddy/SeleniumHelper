using System;

namespace SeleniumHelper
{
    [Serializable]
    public class SeleniumHelperException : Exception
    {
        public SeleniumHelperException()
        {
            throw null;
        }

        public SeleniumHelperException(string message)
        {
            throw new Exception(message);
        }

        public SeleniumHelperException(string message, Exception innerException)
        {
            throw new Exception(message, innerException);
        }
    }
}
