using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region ATRIBUTOS Y PROPIEDADES
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
        public int DNI
        {
            set
            {
                this._dni = this.ValidarDni(this.Nacionalidad, value);
            }
            get
            {
                return this._dni;
            }
        }
        private ENacionalidad _nacionalidad;
        public ENacionalidad Nacionalidad
        {
            set
            {
                // VALIDAR
                this._nacionalidad = value;
            }
            get
            {
                return this._nacionalidad;
            }
        }
        public string StringToDNI
        {
            set
            {
                // VALIDAR
                this.DNI = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region CONSTRUCTORES
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region MÉTODOS
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino)
            {
                if ((dato >= 1) && (dato <= 89999999))
                {
                    return dato;
                }
            }
            else
            {
                if ((dato >= 90000000) && (dato <= 99999999))
                {
                    return dato;
                }
            }
            // VA A CAMBIAR LA EXCEPCION
            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            // VALIDAR
            return int.Parse(dato);
        }
        #endregion
    }
}
