using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Project1.Core.Models;

namespace Project1.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase((uint)1000)]
        public void Test_Client_ConstructorWithParamsCorrectly(uint score)
        {   
            Assert.IsTrue(score > 0);
        }

        [TestCase(1000)]
        public void Test_Transaction_ConstructorWithParamsCorrectly(int amount)
        {
            Assert.IsTrue(amount > 0);
        }

        private static Client setClientObject(uint score)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Score = score
            };
        }

        private static Transaction setTransactionObject(int amount)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                ClientId = Guid.NewGuid(),
                Amount = amount,
                DateTime = new DateTime()
            };
        }
    }
}
