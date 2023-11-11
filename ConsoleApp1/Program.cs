namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperCalculator supercalculator = new SuperCalculator();
            supercalculator += 3;
            supercalculator += 3;
            supercalculator += 1;
            Console.WriteLine($"Resultado {supercalculator.Resultado}");
            Console.ReadKey();
        }
    }

    public class SuperCalculator
    {
        private Stack<int> numeros;

        public SuperCalculator()
        {
            this.numeros = new Stack<int>();
        }

        public double Resultado
        {
            get
            {
                int resultado = 0;
                foreach (int numeros in this.numeros)
                {
                    resultado += numeros;
                }
                return resultado;
            }
        }

        public static SuperCalculator operator +(SuperCalculator superCalculator, int numeros)
        {
            foreach (int item in superCalculator.numeros)
            {
                numeros *= item;
            }
            superCalculator.numeros.Push(numeros);
            return superCalculator;
        }
    }
}