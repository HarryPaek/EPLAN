using AdvDependency.Clients;
using AdvDependency.Factories;
using System;

namespace AdvDependency
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = InstanceFactory.GetMessagePrinter();
            var client = InstanceFactory.GetClient(service);

            client.ExecuteJob();

            Console.ReadKey();
        }
    }
}
