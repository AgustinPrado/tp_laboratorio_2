using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlType("Instructor")]
    public sealed class Instructor : PersonaGimnasio
	{
		#region ATRIBUTOS
		private Queue<Gimnasio.EClases> _clasesDelDia;
		private static Random _random;
		#endregion

		#region CONSTRUCTORES
		static Instructor()
		{
			_random = new Random();
		}

		public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
			this._clasesDelDia = new Queue<Gimnasio.EClases>();
			_randomClases();
		}
		#endregion

		#region MÉTODOS
		protected override string MostrarDatos()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(base.MostrarDatos());
			sb.AppendLine(this.ParticiparEnClase());

			return sb.ToString();
		}

		protected override string ParticiparEnClase()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("CLASES DEL DÍA:");
			foreach (Gimnasio.EClases item in this._clasesDelDia)
			{
				sb.AppendLine(item.ToString());
			}

			return sb.ToString();
		}

		public override string ToString()
		{
			return this.MostrarDatos();
		}

		private void _randomClases()
		{
			this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 4));
			this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 4));
		}
		#endregion

		#region SOBRECARGA DE OPERADORES
		public static bool operator ==(Instructor i, Gimnasio.EClases clase)
		{
			foreach (Gimnasio.EClases item in i._clasesDelDia)
			{
				if (item == clase)
					return true;
			}
			return false;
		}

		public static bool operator !=(Instructor i, Gimnasio.EClases clase)
		{
			return !(i == clase);
		}
		#endregion
	}
}
