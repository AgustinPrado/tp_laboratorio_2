using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Instructor : PersonaGimnasio
	{
		#region ATRIBUTOS
		private Queue<Gimnasio.EClases> _clasesDelDia;
		private static Random _random;
		#endregion

		#region CONSTRUCTORES
        /// <summary>
        /// Constructor de clase que inicializa el random.
        /// </summary>
		static Instructor()
		{
			_random = new Random();
		}

        /// <summary>
        /// Constructor que crea un nuevo instructor.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <param name="nombre">Nombre.</param>
        /// <param name="apellido">Apellido.</param>
        /// <param name="dni">DNI.</param>
        /// <param name="nacionalidad">Nacionalidad.</param>
		public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
			this._clasesDelDia = new Queue<Gimnasio.EClases>();
			_randomClases();
		}

        /// <summary>
        /// Constructor usado para la serialización.
        /// </summary>
        public Instructor()
        {

        }
		#endregion

		#region MÉTODOS
        /// <summary>
        /// Devuelve todos los datos del instructor.
        /// </summary>
        /// <returns>Datos del instructor.</returns>
		protected override string MostrarDatos()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(base.MostrarDatos());
			sb.AppendLine(this.ParticiparEnClase());

			return sb.ToString();
		}

        /// <summary>
        /// Devuelve todas las clases que da el instructor.
        /// </summary>
        /// <returns>Clases que da el instructor.</returns>
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

        /// <summary>
        /// Devuelve todos los datos del instructor.
        /// </summary>
        /// <returns>Datos del instructor.</returns>
		public override string ToString()
		{
			return this.MostrarDatos();
		}

        /// <summary>
        /// Genera aleatoriamente clases que da el instructor.
        /// </summary>
		private void _randomClases()
		{
			this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 4));
			this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(0, 4));
		}
		#endregion

		#region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Compara si el instructor da esa clase.
        /// </summary>
        /// <param name="i">Instructor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>true si el instructor da la clase.</returns>
		public static bool operator ==(Instructor i, Gimnasio.EClases clase)
		{
			foreach (Gimnasio.EClases item in i._clasesDelDia)
			{
				if (item == clase)
					return true;
			}
			return false;
		}

        /// <summary>
        /// Compara si el instructor no da esa clase.
        /// </summary>
        /// <param name="i">Instructor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>true si el instructor no da la clase.</returns>
		public static bool operator !=(Instructor i, Gimnasio.EClases clase)
		{
			return !(i == clase);
		}
		#endregion
	}
}
