using SolidLogger.Model.Enumerations;
using System;

namespace SolidLogger.Model.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}