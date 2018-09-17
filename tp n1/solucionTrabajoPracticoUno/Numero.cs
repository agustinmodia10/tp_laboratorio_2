using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solucionTrabajoPracticoUno
{
    public class Numero
    {
        private double _numero;

        #region Constructores

        public Numero()
        {
            this._numero = 0;
        }

        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        public Numero(double numero)
        {
            this._numero = numero;
        }

        #endregion

        #region Metodos de la clase

        public double getNumero()
        {
            return this._numero;
        }

        private void setNumero(string numero)
        {
            this._numero = validarNumero(numero);
        }

        private double validarNumero(string numeroString)
        {
            double numeroValido;

            if (double.TryParse(numeroString, out numeroValido))
            {
                return numeroValido;
            }
            else
            {
                return 0;
            }
        }

        #endregion

        #region Sobrecargas de operadores

        public static implicit operator Numero(double numero)
        {
            return new Numero(numero);
        }

        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            double resultado;

            resultado = numeroUno._numero + numeroDos._numero;

            return resultado;
        }

        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            double resultado;

            resultado = numeroUno._numero * numeroDos._numero;

            return resultado;
        }

        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
            double resultado;

            resultado = numeroUno._numero - numeroDos._numero;

            return resultado;
        }

        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            double resultado;

            resultado = numeroUno._numero / numeroDos._numero;

            return resultado;
        }

        public static bool operator >(Numero numeroUno, Numero numeroDos)
        {
            if (numeroUno._numero > numeroDos._numero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(Numero numeroUno, Numero numeroDos)
        {
            if (numeroUno._numero < numeroDos._numero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Numero numeroUno, Numero numeroDos)
        {
            if (numeroUno._numero == numeroDos._numero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Numero numeroUno, Numero numeroDos)
        {
            if (numeroUno._numero != numeroDos._numero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Numero numeroUno, double numero)
        {
            if (numeroUno._numero == numero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Numero numeroUno, double numero)
        {
            if (numeroUno._numero == numero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
