using AdvMessagePrinter.Abstracts;
using System;

namespace AdvMessagePrinter
{
    public class MessagePrinterService : IMessagePrinter
    {
        public void PrintMessage()
        {
            Console.WriteLine("AdvMessagePrinter");
            Console.WriteLine("MessagePrinterService PrintMessage()...");
        }
    }
}
