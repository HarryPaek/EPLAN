using AdvDependency.Abstracts;
using AdvDependency.Clients;
using AdvMessagePrinter;
using AdvMessagePrinter.Abstracts;

namespace AdvDependency.Factories
{
    public static class InstanceFactory
    {
        public static IMessageClient GetClient(IMessagePrinter messagePrinter)
        {
            if (messagePrinter == null)
                return new MessageClient(GetMessagePrinter());
            else
                return new MessageClient(messagePrinter);
        }

        public static IMessagePrinter GetMessagePrinter()
        {
            return new MessagePrinterService();
        }
    }
}
