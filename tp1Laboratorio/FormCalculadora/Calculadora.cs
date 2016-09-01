using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormCalculadora
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operacón correspondiente y devuelve el resultado de la misma.
        /// </summary>
        /// <param name="numero1">Primer operando.</param>
        /// <param name="numero2">Segundo operando.</param>
        /// <param name="operador">Operador.</param>
        /// <returns>Resultado de la operación.</returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            // Valido el operador y lo uso directamente para el switch.
            switch(Calculadora.validarOperador(operador))
            {
                case "+":
                    return numero1.getNumero() + numero2.getNumero();
                case "-":
                    return numero1.getNumero() - numero2.getNumero();
                case "/":
                    // Si el divisor es 0, devuelve como resultado 0.
                    if(numero2.getNumero() != 0)
                        return numero1.getNumero() / numero2.getNumero();
                    return 0;
                case "*":
                    return numero1.getNumero() * numero2.getNumero();
                default:
                    // Nunca debería entrar acá, pero por las dudas devuelve como resultado 0.
                    return 0;
            }
        }

        /// <summary>
        /// Valida que el operador sea +, -, * o /.
        /// </summary>
        /// <param name="operador">El operador a validar.</param>
        /// <returns>El operador validado.</returns>
        public static string validarOperador(string operador)
        {
            if (operador.Contains("-"))
                return "-";
            else
            {
                if (operador.Contains("*"))
                    return "*";
                else
                {
                    if (operador.Contains("/"))
                        return "/";
                    return "+";
                }
            }
        }
    }
}
