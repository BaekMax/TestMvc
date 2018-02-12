using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Core.Commands;
using Core.Enums;

namespace Service
{
    /// <summary>
    /// Manage console display
    /// </summary>
    public class Displayer
    {
        private readonly Model _model;

        public Displayer(Model model)
        {
            this._model = model;
        }

        /// <summary>
        /// Display welcome message and first choose for user
        /// </summary>
        /// <param name="firstTime"></param>
        public void DisplayWelcome(bool firstTime)
        {
            if (firstTime)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bienvenue sur HelloAsso v1");
                Console.ResetColor();
            }
            Console.WriteLine("1) afficher l'association 1");
            Console.WriteLine("2) afficher l'association 2");
            Console.WriteLine("3) afficher le parcours de don de l'association 1 pour sa collecte 1");
            Console.WriteLine("q) quitter");
        }

        /// <summary>
        /// Display an organism serialized in JSON
        /// </summary>
        /// <param name="reference"></param>
        public void DisplayOrganism(string reference)
        {
            var organism = new GetOrganismCommand().GetOrganism(reference);
            if (organism.Status != CommandStatus.DONE)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + organism.Message);
                Console.ResetColor();
            }

            Console.WriteLine(new JavaScriptSerializer().Serialize(organism.Output));
        }

        /// <summary>
        /// Entry point to display donation form
        /// </summary>
        /// <param name="organismReference"></param>
        /// <param name="fundraiserReference"></param>
        public void DisplayDonationForm(string organismReference, string fundraiserReference)
        {
            var fundraiser = new GetFundraiserCommand().GetFundraiser(organismReference, fundraiserReference);
            if (fundraiser.Status != CommandStatus.DONE)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + fundraiser.Message);
                Console.ResetColor();
            }

            this._model.Fundraiser = fundraiser.Output;

            DisplayStep1();
        }

        /// <summary>
        /// Donation form step 1: amount selection
        /// </summary>
        public void DisplayStep1()
        {
            Console.WriteLine("Nom: " + this._model.Fundraiser.Name);
            Console.WriteLine("Description: " + this._model.Fundraiser.Description);

            while (true)
            {
                Console.WriteLine("Tarif: ");
                foreach (var actionOption in this._model.Fundraiser.ActionOptionsList)
                {
                    Console.WriteLine(actionOption.Reference + ")" + actionOption.Name + " (" + actionOption.Description +
                                      ") " + actionOption.Amount + "€");
                }

                Console.WriteLine("Merci de choisir le tarif en indiquant sa référence");

                var input = Console.ReadLine();

                if (this._model.Fundraiser.ActionOptionsList.All(o => o.Reference != input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Référence invalide");
                    Console.ResetColor();
                }
                else
                {
                    this._model.OptionReference = input;
                    break;
                }
            }

            this.DisplayStep2();
        }

        /// <summary>
        /// Donation form step 2: user information and additionnal data
        /// </summary>
        public void DisplayStep2()
        {
            while (true)
            {
                Console.WriteLine("Merci d'indiquer votre prénom:");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Prénom invalide");
                    Console.ResetColor();
                }
                else
                {
                    this._model.FirstName = input;
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Merci d'indiquer votre nom:");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nom invalide");
                    Console.ResetColor();
                }
                else
                {
                    this._model.LastName = input;
                    break;
                }
            }

            var infos = this._model.Fundraiser.ActionOptionsList.FirstOrDefault(
                a => a.Reference == this._model.OptionReference).DynamicInfos;

            if (infos != null && infos.Any())
            {
                Console.WriteLine(
                    "Ce tarif nécessite des informations supplémentaires merci de répondre au questions suivantes:");
                Console.WriteLine("(* obligatoire)");
                this._model.Infos = new Dictionary<string, string>();

                foreach (var dynamicInfos in infos)
                {
                    while (true)
                    {
                        Console.WriteLine(dynamicInfos.Name + (dynamicInfos.Required ? "*" : string.Empty) + " (" +
                                          dynamicInfos.Description + ")");
                        var input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input) && dynamicInfos.Required)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ce champ est obligatoire");
                            Console.ResetColor();
                        }
                        else
                        {
                            this._model.Infos.Add(dynamicInfos.Reference, input);
                            break;
                        }
                    }
                }
            }

            this.DisplayStep3();
        }

        /// <summary>
        /// Donation form step 3: tip
        /// </summary>
        public void DisplayStep3()
        {
            var amount = this._model.Fundraiser.ActionOptionsList.FirstOrDefault(
                a => a.Reference == this._model.OptionReference).Amount;

            Console.WriteLine("Merci " + this._model.FirstName + ", tu t'apprêtes à faire un don de " + amount + "€");
            Console.WriteLine("Merci de rentrer la valeur du pourboire (nous te proposont: " + (amount / 100 * 2) + "€)");

            while (true)
            {
                var input = Console.ReadLine();

                var value = 0m;
                if (!decimal.TryParse(input.Replace(",", "."), out value))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Pourboire invalide");
                    Console.ResetColor();
                }
                else
                {
                    this._model.Tip = Convert.ToDecimal(input.Replace(",", "."));
                    break;
                }
            }

            DisplaySuccess();
        }

        /// <summary>
        /// Success step with model serialized in JSON
        /// </summary>
        public void DisplaySuccess()
        {
            Console.WriteLine("Merci ton don est bien pris en compte ci-dessous le détail:");
            Console.WriteLine(new JavaScriptSerializer().Serialize(this._model));
        }
    }
}