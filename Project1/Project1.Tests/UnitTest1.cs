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
        [TestCase(-1000, 1000)]
        [TestCase(1000, 0)]
        public void Test_ViewTransaction_ConstructorWithParams(int score, int money)
        {
            var client = setClientObject(score);
            Assert.Throws<Exception>(delegate () { setViewTransactionObject(client.Id, money); });
        }

        private static Client setClientObject(int score)
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Score = score
            };
        }

        private static ViewTransaction setViewTransactionObject(Guid id, int money)
        {
            return new()
            {
                Id = id,
                Money = money
            };
        }
    }
}
