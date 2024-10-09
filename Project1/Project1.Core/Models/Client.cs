namespace Project1.Core.Models
{
    /// <summary>
    /// Сущность клиент
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Индефикатор клиента
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Денежный счет клиента
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Добавление денег на счет
        /// </summary>
        /// <param name="N">Количество вносимых денег на счет</param>
        public void DepositingMoney(int N)
        {
            Score += N;
        }

        /// <summary>
        /// Снятие денег со счета
        /// </summary>
        /// <param name="K">Количество снимаемых денег со счета</param>
        public void WithdrawalMoney(int K)
        {
            Score -= K;
        }
    }
}
