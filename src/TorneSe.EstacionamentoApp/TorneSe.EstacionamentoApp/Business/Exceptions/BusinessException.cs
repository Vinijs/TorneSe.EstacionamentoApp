using System;

namespace TorneSe.EstacionamentoApp.Business.Exceptions;

public sealed class BusinessException : Exception
{
    public BusinessException()
    {
    }
    public BusinessException(string message) : base(message)
    {
    }

    public BusinessException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
