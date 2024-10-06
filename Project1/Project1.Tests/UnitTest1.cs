using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Project1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase(-1000)]
        public void Test_Client_ConstructorWithParamsCorrectly(int score)
        {   
            Assert.Throws<Exception>(delegate () { setClientObject(score); });
        }

        [TestCase(-1000)]
        public void Test_Transaction_ConstructorWithParamsCorrectly(int amount)
        {
            Assert.Throws<Exception>(delegate () { setClientObject(amount); });
        }

        private static Client setClientObject(int score)
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
