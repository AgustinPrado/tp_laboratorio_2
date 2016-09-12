using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormCalculadora
{
    public class Numero
    {
        private double _numero;

        /// <summary>
        /// Constructor por defecto. Asigna el valor 0.
        /// </summary>
        public Numero():this((double) 0)
        {
            // Llamo al constructor que recibe un double.
        }

        /// <summary>
        /// Asigna el valor que se le pasa por parámetro.
        /// </summary>
        /// <param name="numero">Valor a asignar.</param>
        public Numero(double numero)
        {
            this._numero = numero;
        }

        /// <summary>
        /// Valida y asigna el valor pasado por parámetro.
        /// </summary>
        /// <param name="numero">Valor a validar y asignar.</param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        /// <summary>
        /// Devuelve el valor que tiene el número.
        /// </summary>
        /// <returns>Valor que tiene el número.</returns>
        public double getNumero()
        {
            return this._numero;
        }

        /// <summary>
        /// Valida y setea el valor.
        /// </summary>
        /// <param name="numero">Valor a validar y setear.</param>
        private void setNumero(string numero)
        {
            this._numero = Numero.validarNumero(numero);
        }

        /// <summary>
        /// Valida que el string pasado pueda parsearse a double. Caso contrario devuelve 0.
        /// </summary>
        /// <param name="numeroString">String a parsear.</param>
        /// <returns>Numero ya parseado (double).</returns>
        private static double validarNumero(string numeroString)
        {
            double numeroDouble;
            if (double.TryParse(numeroString, out numeroDouble))
                return numeroDouble;
            return 0;
        }

        /// <summary>
        /// Sobrecarga del operador + que recibe dos objetos Numero y realiza la suma.
        /// </summary>
        /// <param name="numero1">Primer sumando.</param>
        /// <param name="numero2">Segundo sumando.</param>
        /// <returns>Resultado de la suma.</returns>
        public static double operator +(Numero numero1, Numero numero2)
        {
            return numero1.getNumero() + numero2.getNumero();
        }

        /// <summary>
        /// Sobrecarga del operador - que recibe dos objetos Numero y realiza la resta.
        /// </summary>
        /// <param name="numero1">Minuendo.</param>
        /// <param name="numero2">Sustraendo.</param>
        /// <returns>Resultado de la resta.</returns>
        public static double operator -(Numero numero1, Numero numero2)
        {
            return numero1.getNumero() - numero2.getNumero();
        }

        /// <summary>
        /// Sobrecarga del operador / que recibe dos objetos Numero y realiza la división. Valida la división por 0.
        /// </summary>
        /// <param name="numero1">Dividendo.</param>
        /// <param name="numero2">Divisor.</param>
        /// <returns>Resultado de la división.</returns>
        public static double operator /(Numero numero1, Numero numero2)
        {
            // Si el divisor es 0, devuelve como resultado 0.
            if (numero2.getNumero() != 0)
                return numero1.getNumero() / numero2.getNumero();
            return 0;
        }

        /// <summary>
        /// Sobrecarga del operador * que recibe dos objetos Numero y realiza la multiplicación.
        /// </summary>
        /// <param name="numero1">Primer factor.</param>
        /// <param name="numero2">Segundo factor.</param>
        /// <returns>Resultado de la multiplicación.</returns>
        public static double operator *(Numero numero1, Numero numero2)
        {
            return numero1.getNumero() * numero2.getNumero();
        }
    }
}
