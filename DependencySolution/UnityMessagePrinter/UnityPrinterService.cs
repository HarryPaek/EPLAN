using AdvMessagePrinter.Abstracts;
using System;

namespace UnityMessagePrinter
{
    public class UnityPrinterService : IMessagePrinter
    {
        public void PrintMessage()
        {
            Console.WriteLine("UnityMessagePrinter");
            Console.WriteLine("UnityPrinterService PrintMessage()...");
        }
    }
}
