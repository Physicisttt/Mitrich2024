
namespace Project1.Core.Service
{
    public class Rmd
    {
        private readonly int NUM_TRUE = 1;
        private readonly int NUM_FALSE = 0;
        private readonly Random random = new Random();

        public bool FalseOrTrue()
        {
            if (random.NextDouble() < NUM_TRUE / 2) { return false; } else { return true; };
        }
    }
}
