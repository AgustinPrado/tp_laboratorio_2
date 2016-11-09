using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno : PersonaGimnasio
    {
        public enum EEstadoCuenta
        {
            MesPrueba,
            Deudor,
            AlDia
        }

        #region ATRIBUTOS
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor que crea un nuevo alumno.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <param name="nombre">Nombre.</param>
        /// <param name="apellido">Apellido.</param>
        /// <param name="dni">DNI.</param>
        /// <param name="nacionalidad">Nacionalidad.</param>
        /// <param name="claseQueToma">Clase que toma.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor que crea un nuevo alumno con el estado de la cuenta.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <param name="nombre">Nombre.</param>
        /// <param name="apellido">Apellido.</param>
        /// <param name="dni">DNI.</param>
        /// <param name="nacionalidad">Nacionalidad.</param>
        /// <param name="claseQueToma">Clase que toma.</param>
        /// <param name="estadoCuenta">Estado de la cuenta.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Constructor usado para la serialización.
        /// </summary>
        public Alumno()
        {

        }
		#endregion

		#region MÉTODOS
        /// <summary>
        /// Devuelve todos los datos del alumno.
        /// </summary>
        /// <returns>Datos del alumno.</returns>
		protected override string MostrarDatos()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(base.MostrarDatos());
			sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
			sb.AppendLine(this.ParticiparEnClase());

			return sb.ToString();
		}

        /// <summary>
        /// Devuelve la clase que toma el alumno.
        /// </summary>
        /// <returns>Clase que toma el alumno.</returns>
		protected override string ParticiparEnClase()
		{
			return "TOMA CLASES DE " + this._claseQueToma.ToString();
		}

        /// <summary>
        /// Devuelve todos los datos del alumno.
        /// </summary>
        /// <returns>Datos del alumno.</returns>
		public override string ToString()
		{
			return this.MostrarDatos();
		}
		#endregion

		#region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Compara si el alumno no toma la clase.
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>true si el alumno no toma la clase.</returns>
		public static bool operator !=(Alumno a, Gimnasio.EClases clase)
		{
			if (clase != a._claseQueToma)
				return true;
			return false;
		}

        /// <summary>
        /// Compara si el alumno toma la clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>true si el alumno toma la clase y su estado de cuenta no es Deudor.</returns>
		public static bool operator ==(Alumno a, Gimnasio.EClases clase)
		{
			if (!(clase != a._claseQueToma))
			{
				if (a._estadoCuenta != EEstadoCuenta.Deudor)
					return true;
			}
			return false;
		}
		#endregion
	}
}
