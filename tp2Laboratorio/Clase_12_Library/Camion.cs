using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_12_Library_2;

namespace Clase_12_Library
{
    public class Camion : Vehiculo
    {
        /// <summary>
        /// Constructor por defecto para crear un Camión.
        /// </summary>
        /// <param name="marca">Marca del camión</param>
        /// <param name="patente">Patente del camión.</param>
        /// <param name="color">Color del camión.</param>
        public Camion(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        /// <summary>
        /// Los camiones tienen 8 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 8;
            }
        }

        /// <summary>
        /// Devuelve todos los datos del Camión.
        /// </summary>
        /// <returns>Datos del Camión.</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
