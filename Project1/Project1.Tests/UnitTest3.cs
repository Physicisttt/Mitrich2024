using Project1.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Tests
{
    internal class UnitTest3
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void Test_MeasureExecutionTime(int num_threads)
        {
            int num_clients = 1000000;
            var bank = new Bank();
            List<Client> clients = new List<Client>();
            Thread[] threads = new Thread[num_threads];

            for (int i = 0; i < num_clients; i++)
            {
                clients.Add(setClientObject());
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < num_threads; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(Box));
                threads[i].Name = string.Format("Работает поток: #{0}", i);
                threads[i].Start(i);
            }

            stopwatch.Stop();
            Console.WriteLine($"Время работы: {stopwatch.ElapsedMilliseconds}");
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 10);

            void Box(object j)
            {
                int start = num_clients / num_threads * (int)j;
                int end = start + num_clients / num_threads;
                for (int i = start; i < end; i++)
                {
                    bank.PerformTransaction(clients[i]);
                }
            }
        }

        private static Client setClientObject()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Score = 1000
            };
        }
    }
}
