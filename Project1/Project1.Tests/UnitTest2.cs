using Project1.Core.Models;

namespace Project1.Tests
{
    internal class UnitTest2
    {
        [TestCase(1000)]
        [TestCase(5)]
        [TestCase(10000)]
        public void Test_Blockchain_ArchiveTransactionsCorrectly(int num_transactions)
        {
            var blockchain = new Blockchain();
            int isArchive = 0;
            for (int i = 0; i < num_transactions; i++)
            {
                if (!blockchain.AddTransaction(setTransactionObject()))
                {
                    isArchive++; 
                }
            }

            Assert.That(isArchive, Is.EqualTo(num_transactions / 100));
        }

        private static Transaction setTransactionObject()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                ClientId = Guid.NewGuid(),
                Amount = 1000,
                DateTime = new DateTime()
            };
        }
    }
}
