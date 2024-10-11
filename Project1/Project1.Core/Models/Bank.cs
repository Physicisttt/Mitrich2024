namespace Project1.Core.Models
{ 
    /// <summary>
    /// Сущность банк
    /// </summary>
    public class Bank
    {
        private readonly Blockchain[] _blockchains; // Список блокчейнов
        private readonly Random _random;
        private readonly int NUM_BLOCKCHAINS = 10; // Число блокчейнов в списке

        public Bank()
        {
            _blockchains = new Blockchain[NUM_BLOCKCHAINS];
            for (int i = 0; i < NUM_BLOCKCHAINS; i++)
            {
                _blockchains[i] = new Blockchain();
            }
            _random = new Random();
        }

        /// <summary>
        /// Метод для случайной записи транзакции в цепочку блокчейна
        /// </summary>
        /// <param name="clientId">Индефикатор клиента, который совершает транзакцию</param>
        /// <param name="amount">Сумма транзакции, если снял, то amount отрицательный, если положил, то наоборот</param>
        public void PerformTransaction(Client client, uint money)
        {
            if (money < 0) client.DepositingMoney(money);
            else client.WithdrawalMoney(money);

            int blockchainIndex = _random.Next(NUM_BLOCKCHAINS);
            Transaction transaction = new Transaction()
            {
                ClientId = client.Id,
                Amount = money,
                DateTime = DateTime.UtcNow,
            };
            _blockchains[blockchainIndex].AddTransaction(transaction);
        }
    }
}
