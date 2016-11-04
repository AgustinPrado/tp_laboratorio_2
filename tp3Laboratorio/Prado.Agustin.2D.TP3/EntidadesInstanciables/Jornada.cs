using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
	public class Jornada
	{
		#region ATRIBUTOS Y PROPIEDADES
		private List<Alumno> _alumnos;
		private Alumno.EClases _clase;
		private Instructor _instructor;

		public Jornada this[int i]
		{
			get
			{
				// ???
				return this;
			}
		}
		#endregion

		#region CONSTRUCTORES
		private Jornada()
		{
			this._alumnos = new List<Alumno>();
		}

		public Jornada(Alumno.EClases clase, Instructor instructor)
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
			sb.AppendLine("CLASE DE " + this._clase.ToString() + " POR " + this._instructor.ToString());
			foreach (Alumno item in this._alumnos)
			{
				sb.AppendLine(item.ToString());
			}

			return sb.ToString();
			
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
					return j;
			}

			j._alumnos.Add(a);
			return j;
		}
		#endregion
	}
}
