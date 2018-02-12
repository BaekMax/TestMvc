using Core.Commands.Reponse.Interfaces;

namespace Core.Commands.Interfaces
{
    public interface IGetOrganismCommand : ICommand
    {
        /// <summary>
        /// Get an organism by its reference
        /// </summary>
        /// <param name="organismReference">Organism reference</param>
        /// <returns></returns>
        IOrganismCommandResponse GetOrganism(string organismReference);
    }
}