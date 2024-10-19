using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Buchhaltung
{
    internal class LoadProfileMenu : Menu
    {

       Message msg = new Message();
        public override void DisplayMenu()
        {
            Console.WriteLine("Wähle ein Profil aus:");
            Console.WriteLine("---------------------");
            ShowProfiles();           
            string profilePath = InputProfileName();

            if(profilePath != "cancel")
            {
                ProfileManager.LoadProfile(profilePath);
                 Menu nextMenu = new MainMenu();
            }
            else
            {
                Menu nextMenu = new StartMenu();
            }
        }

        private void ShowProfiles() 
        {
            string[] profileFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.prof");

            foreach (string profileFile in profileFiles)
            {
                Console.WriteLine("- " + Path.GetFileName(profileFile));
               
            }
        }

        private string InputProfileName() 
        {
            string input = "";
            while(true)
            {
                Console.Write("Zu ladenes Profil, [\"cancel\" zum abbrechen]: ");
                input = Console.ReadLine();
                string[] profileFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.prof"); 

                bool correctInput = false;

                if (input == "cancel")
                {
                    correctInput = true;
                }
                else
                {
                    for (int i = 0; i < profileFiles.Length; i++)
                    {
                        profileFiles[i] = Path.GetFileName(profileFiles[i]);

                        if (input == profileFiles[i])
                        {
                            correctInput = true;
                            input = AppContext.BaseDirectory +input ;
                            break;
                        }
                    }
                }
                if (correctInput) 
                {
                    break;
                }
                else
                {
                    msg.Error("Ungültiges Profil!");
                }
            }
            return input;
        }
    }


}
