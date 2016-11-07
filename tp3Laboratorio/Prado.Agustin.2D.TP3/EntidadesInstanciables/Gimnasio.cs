using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    
    [Serializable]
    [XmlInclude(typeof(Alumno)), XmlInclude(typeof(Jornada)), XmlInclude(typeof(Instructor))]
    public class Gimnasio
    {
        public enum EClases
        {
            CrossFit,
            Natacion,
            Pilates,
            Yoga
        }

        #region ATRIBUTOS Y PROPIEDADES
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        public Jornada this[int i]
        {
            get
            {
                return this._jornada[i];
            }
        }
        #endregion

        #region CONSTRUCTORES
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }
        #endregion

        #region MÉTODOS
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < gim._jornada.Count; i++)
            {
                sb.AppendLine(gim[i].ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

        public static bool Guardar(Gimnasio gimnasio)
        {
            string pathXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\gimnasio.xml";

            Xml<Gimnasio> xmlFile = new Xml<Gimnasio>();

            xmlFile.guardar(pathXml, gimnasio);

            return true;
        }

        public static Gimnasio Leer(Gimnasio gimnasio)
        {
            string pathXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\gimnasio.xml";
            Gimnasio auxGimnasio;

            Xml<Gimnasio> xmlFile = new Xml<Gimnasio>();

            xmlFile.leer(pathXml, out auxGimnasio);

            return auxGimnasio;
        }
        #endregion

        #region SOBRECARGA DE OPERADORES
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            foreach (Alumno item in g._alumnos)
            {
                if (item.Equals(a))
                    return true;
            }
            return false;
        }

        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Gimnasio g, Instructor i)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item.Equals(i))
                    return true;
            }
            return false;
        }

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        public static Gimnasio operator +(Gimnasio g, Gimnasio.EClases clase)
        {
            /*
            foreach (Instructor instructor in g._instructores)
            {
                if(instructor == clase)
                {
                    Jornada jornada = new Jornada(clase, instructor);
                    
                    foreach (Alumno alumno in g._alumnos)
                    {
                        if (alumno == clase)
                            jornada += alumno;
                    }

                    g._jornada.Add(jornada);

                    return g;
                }
            }

            // EXCEPTION
            return g;
            */
            Jornada jornada = new Jornada(clase, (g == clase));

            foreach (Alumno alumno in g._alumnos)
            {
                if (alumno == clase)
                    jornada += alumno;
            }

            g._jornada.Add(jornada);

            return g;
        }

        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            foreach (Alumno item in g._alumnos)
            {
                if (item.Equals(a))
                    throw new AlumnoRepetidoException();                    
            }

            g._alumnos.Add(a);

            return g;
        }

        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item.Equals(i))
                {
                    // EXCEPTION
                    return g;
                }
            }

            g._instructores.Add(i);

            return g;
        }

        public static Instructor operator ==(Gimnasio g, Gimnasio.EClases clase)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item == clase)
                    return item;
            }

            // EXCEPTION
            throw new SinInstructorException();
        }

        public static Instructor operator !=(Gimnasio g, Gimnasio.EClases clase)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item != clase)
                    return item;
            }

            // Si es que todos pueden dar la clase.
            return null;
        }
        #endregion
    }
}
