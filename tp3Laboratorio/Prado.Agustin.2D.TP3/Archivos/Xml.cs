using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda el dato en un archivo XML.
        /// </summary>
        /// <param name="archivo">Path donde se guardará el archivo XML.</param>
        /// <param name="datos">Datos que se guardarán en el archivo XML.</param>
        /// <returns>true si guardó exitósamente.</returns>
        public bool guardar(string archivo, T datos)
        {
            XmlSerializer ser;
            XmlTextWriter writer;

            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                ser = new XmlSerializer(typeof(T));

                ser.Serialize(writer, datos);

                writer.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee un archivo XML y lo guarda en una clase de tipo T.
        /// </summary>
        /// <param name="archivo">Path donde se leerá el archivo XML.</param>
        /// <param name="datos">Datos que se leerán del archivo XML.</param>
        /// <returns>true si leeyó exitósamente.</returns>
        public bool leer(string archivo, out T datos)
        {
            XmlSerializer ser;
            XmlTextReader reader;

            try
            {
                reader = new XmlTextReader(archivo);
                ser = new XmlSerializer(typeof(T));

                datos = (T)ser.Deserialize(reader);

                reader.Close();

                return true;
            }
            catch (Exception e)
            {
                datos = default(T);
                throw new ArchivosException(e);
            }
        }
    }
}
