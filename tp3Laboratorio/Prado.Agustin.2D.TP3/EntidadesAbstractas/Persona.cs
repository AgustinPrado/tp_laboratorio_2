using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string _apellido;
        public string Apellido
        {
            set
            {
                // VALIDAR
                this._apellido = value;
            }
            get
            {
                return this._apellido;
            }
        }
        private string _nombre;
        public string Nombre
        {
            set
            {
                // VALIDAR
                this._nombre = value;
            }
            get
            {
                return this._nombre;
            }
        }
        private int _dni;
        
        private ENacionalidad _nacionalidad;
    }
}
