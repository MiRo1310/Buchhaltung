using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltung
{
    internal class CreateProfileMenu : Menu
    {
        Message msg = new Message();
        public override void DisplayMenu()
        {
            Console.WriteLine("Profil erstellen");
            Console.WriteLine();

            string profileName = InputName();
            decimal profileStartBalance = InputStartBalance();

            ProfileManager.CreateProfile(profileName, profileStartBalance);

           Menu nextMenu = new MainMenu();
           
        }

        private string InputName()
        {
            while (true) 
            {
                string input = "";
                Console.Write("Profilname: ");
                input = Console.ReadLine();

                if (ValidateName(input))
                {
                    return input;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FEHLER: Ungültiger Name");
                Console.ForegroundColor= ConsoleColor.White;
            }
        }

        private bool ValidateName(string name)
        {
            if(ProfileManager.CheckIfProfileExistst(name))
            {
                return false;
            }

            foreach (char c in name) {
            if(!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            
            }
            return true;
        }

        private decimal InputStartBalance()
        {
            while (true)
            {
                Console.Write("Startkontostand: ");
                decimal input;
                string strInput = Console.ReadLine();

                if(!decimal.TryParse(strInput, out input))
                {
                    msg.Error("Ungültiger Geldbetrag");
                    
                    continue;
                }
                return input;

            }
        }
    }
}
