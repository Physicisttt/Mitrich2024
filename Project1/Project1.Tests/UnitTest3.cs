using Project1.Core.Func;
using Project1.Core.Models;
using System.ComponentModel;
using System.Diagnostics;

namespace Project1.Tests
{
    internal class UnitTest3
    {
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        public void Test_ProgramThreads_MeasureExecutionTime(int num_threads)
        {
            int num_clients = 1000000;
            int max_score = 10000;
            int max_sum_transaction = 5000;

            var stopwatch_no_threads = new Stopwatch();
            var stopwatch_with_threads = new Stopwatch();

            stopwatch_no_threads.Start();
            FuncProgram.ProgramNotThreads(num_clients, max_score, max_sum_transaction);
            stopwatch_no_threads.Stop();
            
            stopwatch_with_threads.Start();
            FuncProgram.ProgramThreads(num_clients, max_score, num_threads, max_sum_transaction);
            stopwatch_with_threads.Stop();


            Assert.IsTrue(stopwatch_with_threads.ElapsedMilliseconds < stopwatch_no_threads.ElapsedMilliseconds);
        }
    }
}
