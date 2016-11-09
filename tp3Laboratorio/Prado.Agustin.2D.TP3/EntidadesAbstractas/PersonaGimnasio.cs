using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class PersonaGimnasio : Persona
    {
        #region ATRIBUTOS
        private int _indentificador;
        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor que crea una nueva PersonaGimnasio
        /// </summary>
        /// <param name="id">ID.</param>
        /// <param name="nombre">Nombre.</param>
        /// <param name="apellido">Apellido.</param>
        /// <param name="dni">DNI.</param>
        /// <param name="nacionalidad">Nacionalidad.</param>
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._indentificador = id;
        }

        /// <summary>
        /// Constructor usado para la serialización.
        /// </summary>
        public PersonaGimnasio()
        {

        }
        #endregion

        #region MÉTODOS
        /// <summary>
        /// Devuelve todos los datos de la PersonaGimnasio.
        /// </summary>
        /// <returns>Datos de la PersonaGimnasio.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("CARNET NÚMERO: " + this._indentificador);

            return sb.ToString();
        }

        /// <summary>
        /// Método abstracto. Se implementará para participar en la clase.
        /// </summary>
        /// <returns>String con la información de la participación en la clase.</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara si dos PersonaGimnasio son iguales.
        /// </summary>
        /// <param name="obj">PersonaGimnasio a comparar.</param>
        /// <returns>true si son iguales.</returns>
        public override bool Equals(object obj)
        {
			return this == (PersonaGimnasio)obj;
        }
        #endregion

        #region SOBRECARGA DE OPERADORES
        /// <summary>
        /// Compara si dos PersonaGimnasio son iguales si y sólo si son del mismo Tipo y su ID o DNI son iguales.
        /// </summary>
        /// <param name="pg1">PersonaGimnasio 1</param>
        /// <param name="pg2">PersonaGimnasio 2</param>
        /// <returns>true si son iguales.</returns>
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

        /// <summary>
        /// Compara si dos PersonaGimnasio son distintas.
        /// </summary>
        /// <param name="pg1">PersonaGimnasio 1</param>
        /// <param name="pg2">PersonaGimnasio 2</param>
        /// <returns>true si son distintas.</returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
