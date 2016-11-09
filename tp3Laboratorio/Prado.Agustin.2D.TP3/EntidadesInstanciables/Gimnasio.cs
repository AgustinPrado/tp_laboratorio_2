using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using EntidadesAbstractas;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    // Hago los include acá porque si lo hago según la convención, me aparece un error cíclico al querer incluir
    // la referencia de EntidadesInstanciables en EntidadesAbstractas.
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(PersonaGimnasio))]
    [XmlInclude(typeof(Persona))]
    [Serializable]
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
        // Para poder serializar.
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
        }
        private List<Instructor> _instructores;
        // Para poder serializar.
        public List<Instructor> Instructores
        {
            get
            {
                return this._instructores;
            }
        }
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
        /// <summary>
        /// Constructor por defecto. Inicializa las listas de alumnos, instructores y jornadas.
        /// </summary>
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Devuelve todos los datos del gimnasio.
        /// </summary>
        /// <param name="gim">Gimnasio a mostrar.</param>
        /// <returns>Datos del gimnasio.</returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < gim._jornada.Count; i++)
            {
                sb.AppendLine(gim[i].ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve todos los datos del gimnasio.
        /// </summary>
        /// <returns>Datos del gimnasio.</returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

        /// <summary>
        /// Guarda el gimnasio en un archivo XML.
        /// </summary>
        /// <param name="gimnasio">Gimnasio a mostrar.</param>
        /// <returns>true si guardó exitosamente.</returns>
        public static bool Guardar(Gimnasio gimnasio)
        {
            string pathXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\gimnasio.xml";

            Xml<Gimnasio> xmlFile = new Xml<Gimnasio>();

            xmlFile.guardar(pathXml, gimnasio);

            return true;
        }

        /// <summary>
        /// Lee el gimnasio que se guardó en un archivo XML y la devuelve como Gimnasio.
        /// </summary>
        /// <returns>Gimnasio leído en formato Gimnasio.</returns>
        public static Gimnasio Leer()
        {
            string pathXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\gimnasio.xml";
            Gimnasio auxGimnasio;

            Xml<Gimnasio> xmlFile = new Xml<Gimnasio>();

            xmlFile.leer(pathXml, out auxGimnasio);

            return auxGimnasio;
        }
        #endregion

        #region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Compara si el alumno está inscripto en el gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>true si el alumno está inscripto en el gimnasio.</returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            foreach (Alumno item in g._alumnos)
            {
                if (item.Equals(a))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Compara si el alumno no está inscripto en el gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>true si el alumno no está inscripto en el gimnasio.</returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compara si el instructor está dando clases en el gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio a comparar.</param>
        /// <param name="i">Instructor a comparar.</param>
        /// <returns>true si el instructor está dando clases en el gimnasio.</returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item.Equals(i))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Compara si el instructor no está dando clases en el gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio a comparar.</param>
        /// <param name="i">Instructor a comparar.</param>
        /// <returns>true si el instructor no está dando clases en el gimnasio.</returns>
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Genera una nueva jornada en el gimnasio con la clase dada.
        /// </summary>
        /// <param name="g">Gimnasio donde se genera la jornada.</param>
        /// <param name="clase">Clase de la jornada.</param>
        /// <returns>Gimnasio con la jornada generada.</returns>
        public static Gimnasio operator +(Gimnasio g, Gimnasio.EClases clase)
        {
            Jornada jornada = new Jornada(clase, (g == clase));

            foreach (Alumno alumno in g._alumnos)
            {
                if (alumno == clase)
                    jornada += alumno;
            }

            g._jornada.Add(jornada);

            return g;
        }

        /// <summary>
        /// Se agrega un alumno al gimnasio, validando que no esté previamente cargado.
        /// </summary>
        /// <param name="g">Gimnasio donde se agrega alumno.</param>
        /// <param name="a">Alumno a agregar.</param>
        /// <returns>Gimnasio con el alumno agregado.</returns>
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

        /// <summary>
        /// Se agrega un instructor al gimnasio, validando que no esté previamente cargado.
        /// </summary>
        /// <param name="g">Gimnasio donde se agrega alumno.</param>
        /// <param name="i">Instructor a agregar.</param>
        /// <returns>Gimnasio con el instructor agregado.</returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            foreach (Instructor item in g._instructores)
            {
                if (item.Equals(i))
                    return g;
            }

            g._instructores.Add(i);

            return g;
        }

        /// <summary>
        /// Devuelve el primer instructor del gimnasio capaz de dar la clase.
        /// </summary>
        /// <param name="g">Gimnasio donde está el instructor.</param>
        /// <param name="clase">Clase que debe dar el instructor.</param>
        /// <returns>Instructor del gimnasio capaz de dar la clase.</returns>
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

        /// <summary>
        /// Devuelve el primer instructor del gimnasio que no es capaz de dar la clase.
        /// </summary>
        /// <param name="g">Gimnasio donde está el instructor.</param>
        /// <param name="clase">Clase que debe dar el instructor.</param>
        /// <returns>Instructor del gimnasio que no es capaz de dar la clase.</returns>
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
