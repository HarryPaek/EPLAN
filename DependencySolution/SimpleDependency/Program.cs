using SimpleDependency.Clients;
using System;

namespace SimpleDependency
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MessageClient();
            client.ExexuteJob();

            Console.ReadKey();
        }
    }
}

