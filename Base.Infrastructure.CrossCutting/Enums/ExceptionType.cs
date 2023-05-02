using System.ComponentModel;

namespace Base.Infrastructure.CrossCutting.Enums
{
    public enum ExceptionType
    {
        [Description(nameof(Ok))]
        Ok = 0,
        [Description(nameof(Error))]
        Error = 1,
    }
}
