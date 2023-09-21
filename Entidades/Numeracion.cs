using System;

namespace Entidades
{
    public enum ESistema { Decimal, Binario };

    public class Numeracion
    {
        private ESistema sistema;
        private string valor;
        private double valorNumerico;

        public Numeracion(double valorNumerico, ESistema sistema)
        {
            this.sistema = sistema;
            this.valorNumerico = valorNumerico;
        }

        public Numeracion(string valor, ESistema eSistema)
        {
            InicializarValores(valor, eSistema);
        }

        public ESistema Sistema
        {
            get
            {
                return sistema;
            }

        }

        public string ValorNumerico
        {
            get
            {
                return valorNumerico.ToString();
            }
        }

        public string GetValor
        {
            get
            {
                return valor;
            }

        }

        // Convertir el valor a binario o a decimal
        public string ConvertirA(ESistema eSistema)
        {
            if (this.sistema == eSistema)
            {
                return this.valor;
            }
            else if (ESistema.Decimal == eSistema)
            {
                return this.BinarioADecimal(this.valor).ToString();
            }
            else
            {
                return this.DecimalABinario(this.valor).ToString();
            }
        }

        // De binario a decimal
        private double BinarioADecimal(string valor)
        {
            if (EsBinario(valor) == true)
            {
                return Convert.ToDouble(valor);
            }
            else
            {
                return 0;
            }
        }

        private string DecimalABinario(int valor)
        {
            if (EsBinario(Convert.ToString(valor)))
            {
                return Convert.ToString(valor);
            }
            else
            {
                return "Numero Invalido";
            }
            /*
            if (valor == 0)
            {
                return "0";
            }
            string resultado = "";

            while (valor > 0)
            {
                int residuo = valor % 2;
                resultado = residuo + resultado;
                valor = valor / 2;
            }
            return resultado;
            */
        }

        // De decimal a Binario
        private string DecimalABinario(string valor)
        {
            if (EsBinario(valor) == false)
            {
                return Convert.ToString(valor);
            }
            else
            {
                return "Numero Invalido";
            }
        }

        // Logica para saber si es o no binario
        private bool EsBinario(string valor)
        {
            foreach (char c in valor)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }

        private void InicializarValores(string valor, ESistema sistema)
        {
            if (!string.IsNullOrEmpty(valor) && ESistema.Binario == sistema)
            {
                this.valorNumerico = this.BinarioADecimal(valor);
            }
            else if (double.TryParse(valor, out double esDecimal))
            {
                this.valorNumerico = esDecimal;
            }
            else
            {
                this.valorNumerico = double.MinValue;
            }
        }

        // Sobrecarga de Operadores Comparativos
        public static bool operator !=(ESistema sistema, Numeracion numeracion)
        {
            return numeracion.sistema != sistema;
        }

        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return n1.sistema != n2.sistema;
        }
        public static bool operator ==(ESistema sistema, Numeracion numeracion)
        {
            return numeracion.sistema == sistema;
        }

        public static bool operator ==(Numeracion n1, Numeracion n2)
        {
            return n1.sistema == n2.sistema;
        }

        // Sobrecarga de Operadores Logicos
        public static double operator -(Numeracion n1, Numeracion n2)
        {
            return n1.valorNumerico - n2.valorNumerico;
        }

        public static double operator *(Numeracion n1, Numeracion n2)
        {
            return n1.valorNumerico * n2.valorNumerico;
        }

        public static double operator /(Numeracion n1, Numeracion n2)
        {
            return n1.valorNumerico / n2.valorNumerico;
        }

        public static double operator +(Numeracion n1, Numeracion n2)
        {
            return n1.valorNumerico + n2.valorNumerico;
        }
    }
}