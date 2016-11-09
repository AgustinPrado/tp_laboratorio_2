using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor que recibe una excepción y se la pasa al base junto a un mensaje fijo.
        /// </summary>
        /// <param name="innerException">Excepción a pasar al base.</param>
        public ArchivosException(Exception innerException)
            : base("Error al guardar el archivo.", innerException)
        {

        }
    }
}
