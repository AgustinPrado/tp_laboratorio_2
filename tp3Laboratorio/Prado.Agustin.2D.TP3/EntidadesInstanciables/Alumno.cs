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
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        public Alumno()
        {
            // Para poder serializar.
        }
		#endregion

		#region MÉTODOS
		protected override string MostrarDatos()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(base.MostrarDatos());
			sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta.ToString());
			sb.AppendLine(this.ParticiparEnClase());

			return sb.ToString();
		}

		protected override string ParticiparEnClase()
		{
			return "TOMA CLASES DE " + this._claseQueToma.ToString();
		}

		public override string ToString()
		{
			return this.MostrarDatos();
		}
		#endregion

		#region SOBRECARGA DE OPERADORES
		public static bool operator !=(Alumno a, Gimnasio.EClases clase)
		{
			if (clase != a._claseQueToma)
				return true;
			return false;
		}

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
