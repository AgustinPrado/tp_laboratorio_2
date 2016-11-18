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

        public Texto(string archivo)
        {
            this._path = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                // false para que sobrescriba. true para que escriba en modo append.
                StreamWriter sw = new StreamWriter(this._path, true);

                sw.WriteLine(datos);

                sw.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool leer(out List<string> datos)
        {
            try
            {
                StreamReader sr = new StreamReader(this._path);

                datos = new List<string>();

                while (!sr.EndOfStream)
                {
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
