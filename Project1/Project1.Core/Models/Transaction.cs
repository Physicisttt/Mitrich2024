namespace Project1.Core.Models
{
    /// <summary>
    /// Сущность транзакция
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Индефикатор транзакции
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Индефикатор клиента который совершает транзакцию
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Сумма транзакции
        /// </summary>
        public uint Amount { get; set; }

        /// <summary>
        /// Временная отметка транзакции
        /// </summary>
        public DateTime DateTime { get; set; }
    }
}
