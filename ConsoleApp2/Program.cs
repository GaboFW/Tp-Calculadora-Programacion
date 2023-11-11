namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = 5;
            Queue<double> data = new Queue<double>();
            int i;

            for (i = max; i > 0; i--)
            {
                data.Enqueue(i);
            }

            for (i = 0; i < max; i++)
            {
                Console.Write($"{data.Dequeue()}");
            }
        }
    }
}