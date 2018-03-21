using AdvMessagePrinter.Abstracts;
using System;
using UnityDependency.Abstracts;
using UnityDependency.DI;

namespace UnityDependency
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageClient client = IoC.Resolve<IMessageClient>();
            client.ExecuteJob();

            Console.ReadKey();
        }
    }
}

