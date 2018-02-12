using System;
using System.Collections.Generic;
using Core.Commands.Interfaces;
using Core.Commands.Reponse;
using Core.Commands.Reponse.Interfaces;
using Core.Enums;
using Core.Types;
using Core.Types.Interfaces;

namespace Core.Commands
{
    public class GetFundraiserCommand : IGetFundraiserCommand
    {
        public IFundraiserCommandResponse GetFundraiser(string organismReference, string fundraiserReference)
        {
            if (string.IsNullOrWhiteSpace(organismReference) || string.IsNullOrWhiteSpace(fundraiserReference))
            {
                return new FundraiserCommandResponse(CommandStatus.BAD_PARAMETER, "all parameter are mandatory", null);
            }

            var organism = new GetOrganismCommand().GetOrganism(organismReference);
            if (organism.Status != CommandStatus.DONE)
            {
                return new FundraiserCommandResponse(organism.Status, organism.Message, null);
            }

            if (organismReference == "1" && fundraiserReference != "1")
            {
                return new FundraiserCommandResponse(CommandStatus.NOT_FOUND, "This fundraiser doesn't exist", null);
            }

            var options = new List<IActionOption>();
            var infos = new List<IDynamicInfos>();
            infos.Add(new DynamicInfos("1", "Numéro d'étudiant", null, true));
            options.Add(new ActionOption("1", "Tarif étudiant", "C'est un tarif réduit pour les étudiants", 10, infos));
            options.Add(new ActionOption("2", "Plein tarif", "C'est le tarif normal", 20, null));
            infos = new List<IDynamicInfos>();
            infos.Add(new DynamicInfos("2", "Pourquoi êtes-vous si généreux ?", null, true));
            infos.Add(new DynamicInfos("3", "Combien gagnez-vous par mois", "C'est juste comme ça !", false));
            options.Add(new ActionOption("3", "Généreux", "Comme le plein tarif mais vous êtes généreux", 100, infos));

            var fundraiser = new Fundraiser(fundraiserReference, "collecte-" + fundraiserReference,
                "Collecte " + fundraiserReference,
                "Ceci est la description de la collecte " + fundraiserReference + " de l'association " +
                organismReference, "col-picture-" + organismReference + "-" + fundraiserReference + ".jpg",
                options, 10);

            return new FundraiserCommandResponse(CommandStatus.DONE, null, fundraiser);
        }
    }
}