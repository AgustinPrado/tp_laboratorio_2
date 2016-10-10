using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_12_Library_2;

namespace Clase_12_Library
{
    public class Concecionaria 
    {
        List<Vehiculo> _vehiculos;
        int _espacioDisponible;
        public enum ETipo
        {
            Moto, Camion, Automovil, Todos
        }

        #region "Constructores"
        private Concecionaria()
        {
            this._vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Constructor público que recibe el espacio disponible.
        /// </summary>
        /// <param name="espacioDisponible">Espacio dispobible de la concecionaria.</param>
        public Concecionaria(int espacioDisponible)
            : this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los vehículos.
        /// </summary>
        /// <returns>Toda la información de la concecionaria.</returns>
        public override string ToString()
        {
            return Concecionaria.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos de la concecionaria y sus vehículos (incluidas sus herencias).
        /// SOLO del tipo requerido.
        /// </summary>
        /// <param name="concecionaria">Concecionaria a exponer.</param>
        /// <param name="ETipo">Tipos de Vehiculos a mostrar.</param>
        /// <returns>Información del tipo requerido de la concecionaria.</returns>
        public static string Mostrar(Concecionaria concecionaria, ETipo tipoDeVehiculo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concecionaria._vehiculos.Count, concecionaria._espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in concecionaria._vehiculos)
            {
                switch (tipoDeVehiculo)
                {
                    case ETipo.Automovil:
                        if(v is Automovil)
                            sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Moto:
                        if(v is Moto)
                            sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Camion:
                        if(v is Camion)
                            sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un vehículo a la concecionaria, siempre que haya espacio disponible.
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se agregará el vehículo.</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a agregar.</param>
        /// <returns>Objeto del tipo Concecionaria con el Vehículo agregado.</returns>
        public static Concecionaria operator +(Concecionaria concecionaria, Vehiculo vehiculo)
        {
            if (concecionaria._vehiculos.Count >= concecionaria._espacioDisponible)
                return concecionaria;
            foreach (Vehiculo v in concecionaria._vehiculos)
            {
                if (v == vehiculo)
                    return concecionaria;
            }

            concecionaria._vehiculos.Add(vehiculo);
            return concecionaria;
        }
        /// <summary>
        /// Quitará un vehículo de la concecionaria.
        /// </summary>
        /// <param name="concecionaria">Objeto del tipo Concecionaria donde se quitará el vehículo.</param>
        /// <param name="vehiculo">Objeto del tipo Vehículo a quitar.</param>
        /// <returns>Objeto del tipo Concecionaria con el Vehículo ya quitado.</returns>
        public static Concecionaria operator -(Concecionaria concecionaria, Vehiculo vehiculo)
        {
            foreach (Vehiculo v in concecionaria._vehiculos)
            {
                if (v == vehiculo)
                {
                    concecionaria._vehiculos.Remove(v);
                    break;
                }
            }

            return concecionaria;
        }
        #endregion
    }
}
