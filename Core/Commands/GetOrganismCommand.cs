using System;
using Core.Commands.Interfaces;
using Core.Commands.Reponse;
using Core.Commands.Reponse.Interfaces;
using Core.Enums;
using Core.Types;

namespace Core.Commands
{
    public class GetOrganismCommand : IGetOrganismCommand
    {
        public IOrganismCommandResponse GetOrganism(string organismReference)
        {
            if (string.IsNullOrWhiteSpace(organismReference))
            {
                return new OrganismCommandResponse(CommandStatus.BAD_PARAMETER, "all parameter are mandatory", null);
            }

            if (organismReference != "1" && organismReference != "2")
            {
                return new OrganismCommandResponse(CommandStatus.NOT_FOUND, "This organism doesn't exist", null);
            }

            var organism = new Organism(organismReference, "asso-" + organismReference,
                "Association " + organismReference, "Ceci est la description de l'association " + organismReference,
                "org-picture-" + organismReference + ".jpg");

            return new OrganismCommandResponse(CommandStatus.DONE, null, organism);
        }
    }
}