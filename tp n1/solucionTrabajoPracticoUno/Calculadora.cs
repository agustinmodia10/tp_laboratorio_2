using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solucionTrabajoPracticoUno
{
    public class Calculadora
    {
        public double operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            double resultado;

            switch (operador)
            {
                case "+":
                    resultado = numeroUno + numeroDos;
                    break;
                case "-":
                    resultado = numeroUno - numeroDos;
                    break;
                case "*":
                    resultado = numeroUno * numeroDos;
                    break;
                case "/":
                    if (numeroDos == 0)
                    {
                        resultado = 0;
                    }
                    else
                    {
                        resultado = numeroUno / numeroDos;
                    }
                    break;
                default:
                    resultado = 0;
                    break;
            }

            return resultado;
        }

        public string validarOperador(string operador)
        {
            if (operador != "*" && operador != "/" && operador != "+" && operador != "-")
            {
                return operador;
            }
            else
            {
                return "+";
            }
        }
    }
}
