using System.Collections.Generic;
using Core.Enums;
using Core.Types.Interfaces;

namespace Core.Commands.Reponse.Interfaces
{
    public interface ICommandResponse<out TOutputType> where TOutputType : ICoreType
    {
        CommandStatus Status { get; }

        string Message { get; }

        TOutputType Output { get; }
    }
}