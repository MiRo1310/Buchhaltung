using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltung
{
        internal class ShowTransactionMenu : Menu
    {
        Message msg = new Message();
        public override void DisplayMenu()
        {
            Console.WriteLine("Gebe den Zeitaraum an!");
            Console.WriteLine("----------------------");

            DateTime startDate = InputDatetime("Startdatum (TT.MM:JJJJ): ", "Ungültiges Startdatum");
            DateTime endDate = InputDatetime("Enddatum (TT.MM:JJJJ): ", "Ungültiges Enddatum", startDate);
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            PrintTransactionsFromTo(startDate, endDate);
            Console.WriteLine("-------------------------");

            Console.WriteLine("Drücke eine taste um zum Hautmenü zurück zu kehren");
            Console.ReadKey();
            Menu nextMenu = new MainMenu();
        }

        private DateTime InputDatetime(string str, string errorMsg, DateTime?datetime=null)
        {
            DateTime input;

            while (true) 
            {
            bool correctInput = true;
            Console.WriteLine(str);

            if(!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input)|| (datetime != null && input < datetime))
                {
                    correctInput = false;
                    msg.Error(errorMsg);
                } 
                if (correctInput)
                {
                    break;
                }
            }
            return input;
         }

        private void PrintTransactionsFromTo(DateTime startDate, DateTime endDate)
        {
            foreach (Transaction transaction in ProfileManager.CurrentProfile.Transactions)
            {

                if (transaction.Date >= startDate && transaction.Date < endDate)
                {
                    if (transaction.Amount > 0)
                    {
                        msg.PositivValue(transaction.ToString());
                    }else 
                    {
                        msg.NegativValue(transaction.ToString());
                    }


                }
            }

        }          

    }
}
