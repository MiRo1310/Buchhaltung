using System;

namespace Buchhaltung
{
    internal class Message
    {        
        public void Error(string str)
        {
            Red();
            WriteMessage("FEHLER: "+ str);
        }

        public void NegativValue(string str)
        {
            Red();
            WriteMessage(str);
        }

        public void PositivValue(string str)
        {
            Green();
            WriteMessage(str);
        }

        private void Red() 
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        private void Green()
        {
            Console.ForegroundColor= ConsoleColor.Green;
        }
        private void WriteMessage(string str)
        {
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
