using Project1.Core.Func;

class Program
{
    static readonly int NUM_CLINTENTS = 1_000_000;
    static readonly int MAX_SCORE = 10_000;
    static readonly int MAX_SUM_TRANSACTION = 5_000;

    static readonly int COUNT_THREAD = 10;
    static void Main()
    {
        FuncProgram.ProgramNotThreads(NUM_CLINTENTS, MAX_SCORE, MAX_SUM_TRANSACTION);
        FuncProgram.ProgramThreads(NUM_CLINTENTS, MAX_SCORE, COUNT_THREAD, MAX_SUM_TRANSACTION);
    }

}