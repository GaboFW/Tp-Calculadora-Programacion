namespace asd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cadena = "-2";
            double resultado;

            if (double.TryParse(cadena, out resultado))
            {
                Console.WriteLine("Conversión exitosa. El valor double es: " + resultado);
            }
            else
            {
                Console.WriteLine("No se pudo realizar la conversión.");
            }
        }
    }
}