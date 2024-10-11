using Project1.Core.Models;
using Project1.Core.Service;
using System.Diagnostics;

namespace Project1.Core.Func
{
    public class FuncProgram
    {
        private static readonly Random Random = new Random();
        private static readonly Rmd rmd = new Rmd();
        public static void ProgramNotThreads(int num_clients, int max_score, int max_sum_transaction)
        {
            Bank bank = new Bank();
            List<Client> clients = new List<Client>();

            for (int i = 0; i < num_clients; i++)
            {
                Client client = new Client()
                {
                    Score = (uint)Random.Next(max_score)
                };
                clients.Add(client);
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            foreach (Client client in clients)
            {
                int money = Random.Next(max_sum_transaction);
                if (rmd.FalseOrTrue())  bank.PerformTransaction(client, -money);
                else bank.PerformTransaction(client, money);


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
                    Score = (uint)Random.Next(max_score)
                };
                clients.Add(client);
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
                    if (rmd.FalseOrTrue()) bank.PerformTransaction(clients[i], -money);
                    else bank.PerformTransaction(clients[i], money);

                }
            }
        }
    }
}
