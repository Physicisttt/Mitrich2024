using Project1.Core.Models;
using Project1.Core.Service;
using System.Diagnostics;

class Program
{
    static readonly int NUM_CLINTENTS = 1000000;
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
        for (int i = 0;i < NUM_CLINTENTS; i++)
        {
            var money = Random.Next();
            if (rmd.FalseOrTrue()) 
            {
                var viewTransaction = new ViewTransaction()
                {
                    Id = clients[i].Id,
                    Money = money,
                };
                //Thread myThread = new Thread(new ParameterizedThreadStart(bank.PerformTransaction));
                //myThread.Start(viewTransaction);
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
                //Thread myThread = new Thread(new ParameterizedThreadStart(bank.PerformTransaction));
                //myThread.Start(viewTransaction);
                //bank.PerformTransaction(viewTransaction);
                //clients[i].WithdrawalMoney(money);
            }
        }
        stopWatch.Stop();
        Console.WriteLine("\t" + stopWatch + "\t");
        Console.WriteLine("Все транзакции выполнены.");
    }
}