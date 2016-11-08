using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml;
using System.Xml.Serialization;

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
		private Jornada()
		{
			this._alumnos = new List<Alumno>();
		}

		public Jornada(Gimnasio.EClases clase, Instructor instructor)
			: this()
        {
			this._clase = clase;
			this._instructor = instructor;
		}
		#endregion

		#region MÉTODOS
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

        public static bool Guardar(Jornada jornada)
        {
            string pathTexto = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";

            Texto text = new Texto();

            text.guardar(pathTexto, jornada.ToString());

            return true;         
        }

        public static string Leer(Jornada jornada)
        {
            string pathTexto = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";
            string aux;

            Texto text = new Texto();

            text.leer(pathTexto, out aux);

            return aux;
        }
		#endregion

		#region SOBRECARGA DE OPERADORES
		public static bool operator ==(Jornada j, Alumno a)
		{
			return (a == j._clase);
		}

		public static bool operator !=(Jornada j, Alumno a)
		{
			return !(j == a);
		}

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
