using AdvMessagePrinter.Abstracts;
using UnityDependency.Abstracts;

namespace UnityDependency.Clients
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
