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
        /// <summary>
        /// Проверяется наличие денег клиента при выводе средств
        /// </summary>
        /// <param name="score">Счет</param>
        /// <param name="money">Количество денег для вывода или пополнения</param>
        [TestCase(1000, 1000)]
        [TestCase(1000, -1000)]
        [TestCase(0, -1000)]
        public void TestThat_ViewTransaction_EnoughMoney(int score, int money)
        {
            var client = setClientObject(score);
            var viewTransaction = setViewTransactionObject(client.Id, money);

            Assert.True(enoughMoney(viewTransaction, client));
        }

        private static bool enoughMoney(ViewTransaction newTransaction, Client client)
        {
            if (newTransaction.Money < 0)
            {
                if (-newTransaction.Money > client.Score)
                {
                    return false;
                }
            }
            return true;
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
