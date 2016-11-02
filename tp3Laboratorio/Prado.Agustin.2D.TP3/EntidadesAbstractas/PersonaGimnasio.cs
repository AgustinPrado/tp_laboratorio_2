using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio : Persona
    {
        #region ATRIBUTOS
        private int _indentificador;
        #endregion

        #region CONSTRUCTORES
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._indentificador = id;
        }
        #endregion

        #region MÉTODOS
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("CARNET NÚMERO: " + this._indentificador);

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            return this == obj;
        }
        #endregion

        #region SOBRECARGA DE OPERADORES
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (pg1.GetType() == pg2.GetType())
            {
                if (pg1._indentificador == pg2._indentificador)
                    return true;
                if (pg1.DNI == pg2.DNI)
                    return true;
            }
            return false;
        }

        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
