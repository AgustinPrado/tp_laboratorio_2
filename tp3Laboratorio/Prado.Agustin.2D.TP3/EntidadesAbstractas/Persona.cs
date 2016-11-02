﻿using System;
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
                this._apellido = this.ValidarNombreApellido(value);
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
                this._nombre = this.ValidarNombreApellido(value);
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
            throw new DniInvalidoException("La nacionalidad no se condice con el número de DNI");
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                return int.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(e);
            }

        }

        private string ValidarNombreApellido(string dato)
        {
            foreach (Char item in dato)
            {
                if (!Char.IsLetter(item) && item != 32)
                {
                    return "String no válido.";
                }
            }
            return dato;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", 
                this.Apellido,
                this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());

            return sb.ToString();
        }
        #endregion
    }
}
