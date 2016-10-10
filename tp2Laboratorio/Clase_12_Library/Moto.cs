using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Clase_12_Library_2;

namespace Clase_12_Library
{
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Constructor por defecto para crear una Moto.
        /// </summary>
        /// <param name="marca">Marca de la moto.</param>
        /// <param name="patente">Patente de la moto.</param>
        /// <param name="color">Color de la moto.</param>
        public Moto(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }
        /// <summary>
        /// Las motos tienen 2 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Devuelve todos los datos de la Moto.
        /// </summary>
        /// <returns>Datos de la Moto.</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("RUEDAS : {0}", this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
