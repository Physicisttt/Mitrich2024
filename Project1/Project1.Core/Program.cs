using Project1.Core.Models;
using Project1.Core.Service;
using System.Diagnostics;

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
        ProgramNotThreads(NUM_CLINTENTS, MAX_SCORE, MAX_SUM_TRANSACTION);
        ProgramThreads(NUM_CLINTENTS, MAX_SCORE, COUNT_THREAD, MAX_SUM_TRANSACTION);
    }
    
    public static void ProgramNotThreads(int num_clients, int max_score, int max_sum_transaction)
    {
        Bank bank = new Bank();
        List<Client> clients = new List<Client>();

        for (int i = 0; i < num_clients; i++)
        {
            Client client = new Client()
            {
                Score = Random.Next(max_score)
            };
            clients.Add(client);
        }

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
                

        foreach (Client client in clients)
        {
            var money = Random.Next(max_sum_transaction);
            if (rmd.FalseOrTrue()) client.DepositingMoney(money);
            else client.WithdrawalMoney(money);

            bank.PerformTransaction(client, money);
        }

        stopWatch.Stop();
        Console.WriteLine("\t" + stopWatch + "\t" + "\n");
        Console.WriteLine("Все транзакции выполнены.");
    }

    public static void ProgramThreads(int num_clients, int max_score, int count_thread, int max_sum_transaction)
    {
        Bank bank = new Bank();
        List<Client> clients = new List<Client>();
        Thread[] threads = new Thread[count_thread];

        for (int i = 0; i < num_clients; i++)
        {
            Client client = new Client()
            {
                Score = Random.Next(max_score)
            };
            clients.Add(client);

            var money = Random.Next(max_sum_transaction);
            if (rmd.FalseOrTrue()) clients[i].DepositingMoney(money);
            else clients[i].WithdrawalMoney(money);
        }
        
        
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 0; i < count_thread; i++)
        {
            threads[i] = new Thread(new ParameterizedThreadStart(Box));
            threads[i].Name = string.Format("Работает поток: #{0}", i);
            threads[i].Start(i);
        }

        stopWatch.Stop();
        Console.WriteLine("\t" + stopWatch + "\t" + "\n");
        Console.WriteLine("Все транзакции выполнены.");

        void Box(object j)
        {
            int start = num_clients / count_thread * (int)j;
            int end = start + num_clients / count_thread;
            for (int i = start; i < end; i++)
            {
                var money = Random.Next(max_sum_transaction);
                if (rmd.FalseOrTrue()) clients[i].DepositingMoney(money);
                else clients[i].WithdrawalMoney(money);

                bank.PerformTransaction(clients[i], money);
            }
        }
    }

}