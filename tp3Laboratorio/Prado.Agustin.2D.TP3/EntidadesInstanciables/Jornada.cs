using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
	{
		#region ATRIBUTOS Y PROPIEDADES
		private List<Alumno> _alumnos;
		private Gimnasio.EClases _clase;
		private Instructor _instructor;
		#endregion

		#region CONSTRUCTORES
        /// <summary>
        /// Constructor por defecto que inicializa la lista de alumnos.
        /// </summary>
		private Jornada()
		{
			this._alumnos = new List<Alumno>();
		}

        /// <summary>
        /// Constructor que inicializa la clase y al instructor que recibe como parámetros.
        /// </summary>
        /// <param name="clase">Clase que se da en la jornada.</param>
        /// <param name="instructor">Instructor que da la clase.</param>
		public Jornada(Gimnasio.EClases clase, Instructor instructor)
			: this()
        {
			this._clase = clase;
			this._instructor = instructor;
		}
		#endregion

		#region MÉTODOS
        /// <summary>
        /// Datos de la jornada.
        /// </summary>
        /// <returns>Datos completos de la jornada.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("JORNADA:");
			sb.Append("CLASE DE " + this._clase.ToString() + " POR " + this._instructor.ToString());
            sb.AppendLine("ALUMNOS:");
			foreach (Alumno item in this._alumnos)
			{
				sb.AppendLine(item.ToString());
			}
            sb.AppendLine("<---------------------------------------------------------------->");

			return sb.ToString();
			
		}

        /// <summary>
        /// Guarda la jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada a guardar.</param>
        /// <returns>true si guardó exitosamente.</returns>
        public static bool Guardar(Jornada jornada)
        {
            string pathTexto = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";

            Texto text = new Texto();

            text.guardar(pathTexto, jornada.ToString());

            return true;         
        }

        /// <summary>
        /// Lee la jornada que se guardó en un archivo de texto y la devuelve como string.
        /// </summary>
        /// <returns>Jornada leída en formato string.</returns>
        public static string Leer()
        {
            string pathTexto = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";
            string aux;

            Texto text = new Texto();

            text.leer(pathTexto, out aux);

            return aux;
        }
		#endregion

		#region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Compara si el alumno participa de la clase de la jornada.
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns></returns>
		public static bool operator ==(Jornada j, Alumno a)
		{
			return (a == j._clase);
		}

        /// <summary>
        /// Compara si el alumno no participa de la clase de la jornada.
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns></returns>
		public static bool operator !=(Jornada j, Alumno a)
		{
			return !(j == a);
		}

        /// <summary>
        /// Agrega un alumno a la jornada.
        /// </summary>
        /// <param name="j">Jornada a la que se va a sumar el alumno.</param>
        /// <param name="a">Alumno a sumar a la jornada.</param>
        /// <returns>Jornada con el alumno sumado.</returns>
		public static Jornada operator +(Jornada j, Alumno a)
		{
			foreach (Alumno item in j._alumnos)
			{
				if (item.Equals(a))
                    throw new AlumnoRepetidoException();
			}

			j._alumnos.Add(a);
			return j;
		}
		#endregion
	}
}
