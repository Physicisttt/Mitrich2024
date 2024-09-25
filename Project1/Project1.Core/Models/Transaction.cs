namespace Project1.Core.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        public int Amount { get; set; }

        public DateTime DateTime { get; set; }
    }
}
