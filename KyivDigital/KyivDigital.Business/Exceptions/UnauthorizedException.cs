using System;
namespace KyivDigital.Business.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string error) : base(error) { }
    }
}