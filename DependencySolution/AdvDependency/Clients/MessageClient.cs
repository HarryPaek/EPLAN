using AdvDependency.Abstracts;
using AdvMessagePrinter.Abstracts;

namespace AdvDependency.Clients
{
    public class MessageClient : IMessageClient
    {
        public readonly IMessagePrinter _service = null;

        public MessageClient(IMessagePrinter service)
        {
            this._service = service;
        }

        public void ExecuteJob()
        {
            this._service.PrintMessage();
        }
    }
}

