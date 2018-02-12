using Core.Commands.Reponse.Interfaces;

namespace Core.Commands.Interfaces
{
    public interface IGetFundraiserCommand : ICommand
    {
        /// <summary>
        /// Get a fundraiser campaign from organism reference and fundraiser reference
        /// </summary>
        /// <param name="organismReference">Reference of the organism owner of campaign</param>
        /// <param name="fundraiserReference">Fundraiser reference</param>
        /// <returns></returns>
        IFundraiserCommandResponse GetFundraiser(string organismReference, string fundraiserReference);
    }
}