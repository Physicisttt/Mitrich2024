using Project1.Core.Models;
using Project1.Core.Service;
using System.Diagnostics;

class Program
{
    static readonly int NUM_CLINTENTS = 1_000_000;
    static readonly Random Random = new Random();
    static readonly Rmd rmd = new Rmd();
    static void Main()
    {
        Bank bank = new Bank();
        List<Client> clients = new List<Client>();

        for (int i = 0; i < NUM_CLINTENTS; i++)
        {
            Client client = new Client()
            {
                Score = Random.Next()
            };
            clients.Add(client);
        }
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        Thread[] clients2 = new Thread[NUM_CLINTENTS];
        for (int i = 0; i < NUM_CLINTENTS; i++)
        {
            var money = Random.Next();
            if (rmd.FalseOrTrue())
            {
                var viewTransaction = new ViewTransaction()
                {
                    Id = clients[i].Id,
                    Money = money,
                };
                clients2[i] = new Thread(new ParameterizedThreadStart(bank.PerformTransaction));
                clients2[i].Start(viewTransaction);
               
                //bank.PerformTransaction(viewTransaction);
                //clients[i].DepositingMoney(money);
            }
            else
            {
                var viewTransaction = new ViewTransaction()
                {
                    Id = clients[i].Id,
                    Money = -money,
                };
                clients2[i] = new Thread(new ParameterizedThreadStart(bank.PerformTransaction));
                clients2[i].Start(viewTransaction);
                //bank.PerformTransaction(viewTransaction);
                //clients[i].WithdrawalMoney(money);
            } 
        }
        for (int i = 0; i < NUM_CLINTENTS; i++)
        {
            clients2[i].Join();
        }
        stopWatch.Stop();
        Console.WriteLine("\t" + stopWatch + "\t");
        Console.WriteLine("Все транзакции выполнены.");
    }
}