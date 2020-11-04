using System;

namespace Appreciation.Manager.Services.Contracts.Exceptions
{
    public sealed class ConversionTypeNotAllowedException : Exception
    {
        const string ERROR = "Convert type not allowed";
        public ConversionTypeNotAllowedException(): base(ERROR)
        {

        }
    }
}
