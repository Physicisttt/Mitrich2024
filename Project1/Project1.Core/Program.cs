using Project1.Core.Models;
using Project1.Core.Service;
using System.Diagnostics;
using System.Threading;

class Program
{
    static readonly int NUM_CLINTENTS = 1_000_000;
    static readonly Random Random = new Random();
    static readonly Rmd rmd = new Rmd();
    static readonly int MAX_SCORE = 10_000;
    static readonly int MAX_SUM_TRANSACTION = 5_000;

    static readonly int COUNT_THREAD = 10;
    static void Main()
    {
        Bank bank = new Bank();
        List<Client> clients = new List<Client>();
        Thread[] threads = new Thread[COUNT_THREAD];

        for (int i = 0; i < NUM_CLINTENTS; i++)
        {
            Client client = new Client()
            {
                Score = Random.Next(MAX_SCORE)
            };
            clients.Add(client);
        }

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        
        for (int i = 0; i < COUNT_THREAD; i++)
        {
            threads[i] = new Thread(new ParameterizedThreadStart(Box));
            threads[i].Name = string.Format("Работает поток: #{0}", i);
            threads[i].Start(i);
        }

        /*foreach (Client client in clients)
        {
            bank.PerformTransaction(client);
        }*/

        stopWatch.Stop();
        Console.WriteLine("\t" + stopWatch + "\t" + "\n");
        Console.WriteLine("Все транзакции выполнены.");

        void Box(object j)
        {
            int start = NUM_CLINTENTS / COUNT_THREAD * (int)j;
            int end = start + NUM_CLINTENTS / COUNT_THREAD;
            for (int i = start; i < end; i++)
            {
                bank.PerformTransaction(clients[i]);
            }
        }
    }

}