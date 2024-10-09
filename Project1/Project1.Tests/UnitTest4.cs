using Project1.Core.Models;

namespace Project1.Tests
{
    internal class UnitTest4
    {
        [Test]
        public void Test_PerformTransaction_ChangeScoreCorrectly()
        {
            var client = setClientObject();
            int original_score = client.Score;
            var bank = new Bank();
            bank.PerformTransaction(client);
            Assert.That(client.Score, Is.Not.EqualTo(original_score));
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
