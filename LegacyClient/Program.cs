using System;
using Service;

namespace LegacyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var displayer = new Displayer(new Model());

            displayer.DisplayWelcome(true);

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "1" || input == "2")
                {
                    displayer.DisplayOrganism(input);
                }
                else if (input == "3")
                {
                    displayer.DisplayDonationForm("1", "1");
                }
                else if (input == "q")
                {
                    break;
                }

                displayer.DisplayWelcome(false);
            }
        }
    }
}