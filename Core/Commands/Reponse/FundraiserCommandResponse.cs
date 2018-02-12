using Core.Commands.Reponse.Interfaces;
using Core.Enums;
using Core.Types.Interfaces;

namespace Core.Commands.Reponse
{
    public class FundraiserCommandResponse : IFundraiserCommandResponse
    {
        public CommandStatus Status { get; }
        public string Message { get; }
        public IFundraiser Output { get; }

        public FundraiserCommandResponse(CommandStatus status, string message, IFundraiser fundraiser)
        {
            this.Status = status;
            this.Message = message;
            this.Output = fundraiser;
        }
    }
}