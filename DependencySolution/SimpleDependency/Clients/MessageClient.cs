using SimpleMessagePrinter;

namespace SimpleDependency.Clients
{
    public class MessageClient
    {
        public void ExexuteJob()
        {
            var service = new MessagePrinterService();
            service.PrintMessage();
        }
    }
}


