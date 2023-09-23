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

        public string Valor
        {
            get
            {
                return valor;
            }

        }

        /// <summary>
        /// Convertir el valor decimal a binario y viceversa
        /// </summary>
        /// <param name="eSistema"></param>
        /// <returns></returns>
        public string ConvertirA(ESistema eSistema)
        {
            // Decimal a binario
            if (ESistema.Decimal == eSistema)
            {
                return this.BinarioADecimal(this.valor).ToString();
            }

            // Binario a decimal
            else
            {
                return this.DecimalABinario(this.valor).ToString();
            }
        }

        /// <summary>
        /// De binario a decimal
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Metodo decimal a binario
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private string DecimalABinario(int valor)
        {
            if (EsBinario(valor.ToString()))
            {
                return valor.ToString();
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

        /// <summary>
        /// De decimal a Binario
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private string DecimalABinario(string valor)
        {
            if (EsBinario(valor) == false)
            {
                return valor.ToString();
            }
            else
            {
                return "Numero Invalido";
            }
        }

        /// <summary>
        /// Logica para saber si es o no binario
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private bool EsBinario(string valor)
        {
            foreach (char c in valor)
            {
                if (c.ToString() != "0" && c.ToString() != "1")
                {
                    return false;
                }
            }
            return true;
        }

        private void InicializarValores(string valor, ESistema sistema)
        {

            if (!string.IsNullOrEmpty(valor) && (sistema == ESistema.Binario))
            {
                this.valorNumerico = BinarioADecimal(valor);
            }
            else if (sistema == ESistema.Decimal)
            {
                this.valorNumerico = double.Parse(valor);
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