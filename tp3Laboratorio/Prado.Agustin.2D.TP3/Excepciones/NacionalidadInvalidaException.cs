using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor por defecto. Pasa un mensaje fijo al base.
        /// </summary>
        public NacionalidadInvalidaException()
            : base("La nacionalidad no se condice con el número de DNI.")
        {
            
        }

        /// <summary>
        /// Constructor que recibe un mensaje como parámetro y se lo pasa al base.
        /// </summary>
        /// <param name="message">Mensaje a pasar al base.</param>
        public NacionalidadInvalidaException(string message)
            : base(message)
        {
            
        }
    }
}
