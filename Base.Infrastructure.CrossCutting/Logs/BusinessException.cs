using System;

namespace Base.Infrastructure.CrossCutting.Logs
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        {
            Log.Error(this, message);
        }
    }
}
