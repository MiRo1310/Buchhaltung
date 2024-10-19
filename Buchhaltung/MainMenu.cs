using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltung
{
    internal class MainMenu : Menu
    {
        Message msg = new Message();
        public override void DisplayMenu()
        {
            Console.WriteLine("Profil: " + ProfileManager.CurrentProfile.Name);
            Console.WriteLine("Aktueller Kontostand: " + ProfileManager.CurrentProfile.Balance + " Euro");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
            Console.WriteLine("[1] Neue Transaktion");
            Console.WriteLine("[2] Zeige Transaktionen");
            Console.WriteLine("[3] Zurück ins Startmenu");
            Console.WriteLine();
            InputOption();
        }
        private void InputOption()
        {
            string input;
            while (true)
            {
                Console.Write("Eingabe: ");
                input = Console.ReadLine();

                bool correctInput = true;

                Menu nextMenu;

                switch (input)
                {
                    case "1":
                        nextMenu = new NewTransactionMenu();
                        break;
                    case "2":
                         nextMenu = new ShowTransactionMenu();
                        break;
                    case "3":
                        nextMenu = new StartMenu();
                        break;
                    default:
                        correctInput = false;
                        msg.Error("Ungültige Eingabe");                        
                        break;
                }
                if (correctInput)
                {
                    break;
                }
            }
        }
    }

  
}
