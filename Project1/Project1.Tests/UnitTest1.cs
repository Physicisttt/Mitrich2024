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
            Assert.Throws<Exception>(delegate () { setClientObject(score); });
        }

        [TestCase((uint)1000)]
        public void Test_Transaction_ConstructorWithParamsCorrectly(uint amount)
        {
            Assert.Throws<Exception>(delegate () { setClientObject(amount); });
        }

        private static Client setClientObject(uint score)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Score = score
            };
        }

        private static Transaction setTransactionObject(uint amount)
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
