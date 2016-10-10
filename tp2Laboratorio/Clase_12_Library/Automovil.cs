using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_12_Library_2;

namespace Clase_12_Library
{
    public class Automovil : Vehiculo
    {
        /// <summary>
        /// Constructor por defecto que crea un Automóvil.
        /// </summary>
        /// <param name="marca">Marca del automóvil.</param>
        /// <param name="patente">Patente del automóvil.</param>
        /// <param name="color">Color del automóvil.</param>
        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        /// <summary>
        /// Los automoviles tienen 4 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 4;
            }
        }

        /// <summary>
        /// Devuelve todos los datos del Automóvil.
        /// </summary>
        /// <returns> Datos del Automóvil.</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
