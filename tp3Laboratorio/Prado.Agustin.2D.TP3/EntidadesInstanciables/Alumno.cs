using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public class Alumno : PersonaGimnasio
    {
        public enum EClases
        {
            Crossfit,
            Natacion,
            Pilates,
            Yoga
        }
        public enum EEstadoCuenta
        {
            MesPrueba,
            Deudor,
            AlDia
        }

        #region ATRIBUTOS
        private EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion

        #region CONSTRUCTORES
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion
    }
}
