using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _path;

        /// <summary>
        /// Constructor que recibe el path del archivo.
        /// </summary>
        /// <param name="archivo">Path del archivo.</param>
        public Texto(string archivo)
        {
            this._path = archivo;
        }

        /// <summary>
        /// Guarda los datos en un archivo de texto.
        /// </summary>
        /// <param name="datos">Datos a guardar.</param>
        /// <returns>true si fue exitoso el guardado. false si falló.</returns>
        public bool guardar(string datos)
        {
            try
            {
                // false para que sobrescriba. true para que escriba en modo append.
                StreamWriter sw = new StreamWriter(this._path, true);

                // escribo cada dato en una nueva línea.
                sw.WriteLine(datos);

                sw.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Leo todos los datos del archivo en una lista de strings.
        /// </summary>
        /// <param name="datos">Lista de strings donde se guardarán los datos.</param>
        /// <returns>true si fue exitosa la lectura. false si falló.</returns>
        public bool leer(out List<string> datos)
        {
            try
            {
                StreamReader sr = new StreamReader(this._path);

                datos = new List<string>();

                while (!sr.EndOfStream)
                {
                    // ingreso cada linea en un nuevo item en la lista.
                    datos.Add(sr.ReadLine());
                }
                               
                sr.Close();

                return true;
            }
            catch (Exception)
            {
                datos = default(List<string>);
                return false;
            }
        }
    }
}
