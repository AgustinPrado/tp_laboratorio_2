using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Guarda datos en un archivo.
        /// </summary>
        /// <param name="archivo">Path del archivo.</param>
        /// <param name="datos">Datos a guardar.</param>
        /// <returns>true si se guardó exitósamente.</returns>
        bool guardar(string archivo, T datos);
        /// <summary>
        /// Lee datos de un archivo.
        /// </summary>
        /// <param name="archivo">Path del archivo.</param>
        /// <param name="datos">Datos que se leen.</param>
        /// <returns>true si se leyó exitósamente.</returns>
        bool leer(string archivo, out T datos);
    }
}
