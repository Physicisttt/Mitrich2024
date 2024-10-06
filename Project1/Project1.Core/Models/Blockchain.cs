namespace Project1.Core.Models
{
    /// <summary>
    /// Сущность блокчейн
    /// </summary>
    public class Blockchain
    {
        private readonly List<Transaction> _transactions; // Цепочка блокчейна
        private readonly int MAX_TRANSACTIONS = 100; // Максимальное число транзакций в цепочке

        public Blockchain()
        {
            _transactions = new List<Transaction>();
        }

        /// <summary>
        /// Добавляем транзакцию в цепочку блокчейна
        /// </summary>
        /// <param name="transaction">Объект транзакций</param>
        /// <returns></returns>
        public bool AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            if (_transactions.Count >= MAX_TRANSACTIONS)
            {
                Archive();
                return false; // Уведомляем, что цепочка полная
            }
            return true; // Уведомляем, что транзакция успешно добавлена
        }

        /// <summary>
        /// Добавляем цепочку в архим
        /// </summary>
        private void Archive()
        {
            //Console.WriteLine($"Цепочка архивирована с {MAX_TRANSACTIONS} транзакциями.");
            _transactions.Clear(); // Очищаем транзакции после архивирования
        }
    }
}
