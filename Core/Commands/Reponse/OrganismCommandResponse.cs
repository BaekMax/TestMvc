using Core.Commands.Reponse.Interfaces;
using Core.Enums;
using Core.Types.Interfaces;

namespace Core.Commands.Reponse
{
    public class OrganismCommandResponse : IOrganismCommandResponse
    {
        public CommandStatus Status { get; }
        public string Message { get; }
        public IOrganism Output { get; }

        public OrganismCommandResponse(CommandStatus status, string message, IOrganism organism)
        {
            this.Status = status;
            this.Message = message;
            this.Output = organism;
        }
    }
}