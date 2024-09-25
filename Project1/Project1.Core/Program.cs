using Project1.Core.Models;
using Project1.Core.Service;

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

        for (int i = 0;i < NUM_CLINTENTS; i++)
        {
            var money = Random.Next();
            if (rmd.FalseOrTrue()) 
            {
                bank.PerformTransaction(clients[i].Id, money);
                clients[i].DepositingMoney(money);
            }
            else
            {
                bank.PerformTransaction(clients[i].Id, -money);
                clients[i].WithdrawalMoney(money);
            }
        }
        Console.WriteLine("Все транзакции выполнены.");
    }
}