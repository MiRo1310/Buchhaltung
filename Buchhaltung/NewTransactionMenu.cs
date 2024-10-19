using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltung
{
    internal class NewTransactionMenu : Menu
    {
        Message msg = new Message();
        public override void DisplayMenu()
        {
            Console.WriteLine("Neue Transaction");
            Console.WriteLine("----------------");

            string newTransactionName = InputTransactionName();
            decimal newTransactionAmount = InputTransactionAmount();
            DateTime newTransactionDateTime = InputTransactionDate();

            Transaction transaction = new Transaction(newTransactionName, newTransactionAmount, newTransactionDateTime);

            ProfileManager.CurrentProfile.AddTransaction(transaction);

            Console.WriteLine("Die folgende Transaktion wurde hinzugefügt");

            if (transaction.Amount > 0)
            {
                msg.PositivValue(transaction.ToString());
            }
            else 
            {
            msg.NegativValue(transaction.ToString());
            }

            Console.ReadKey();

            Menu next = new MainMenu();

        }
        private string InputTransactionName()
        {
            Console.Write("Transaktions-Name: ");
            return Console.ReadLine();
        }

        private decimal InputTransactionAmount()
        {
            decimal input;

                while(true)
            {
                Console.WriteLine("Eutro-Betrag: ");
                bool correctInput = true;
                if (!decimal.TryParse(Console.ReadLine(), out input))
                {
                    correctInput = false;
                    msg.Error("Ungültiger Euro-Betrag");
                    continue;
                }
                if (correctInput)
                {
                    break;
                }
            }
            

            return input;
        }

        private DateTime InputTransactionDate()
        {
            DateTime input;
            while (true)
            {
                Console.Write("Datum (TT.MM.JJJJ): ");
                bool correctInput = true;

                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input))
                    {
                    correctInput = false;
                    msg.Error("Ungültiges Datum");

                }
                if(correctInput)
                {
                    break;
                }
            }
            return input; 
        }
    }
}
