using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto que pasa un mensaje fijo al base.
        /// </summary>
        public AlumnoRepetidoException()
            : base("Alumno repetido.")
        {

        }
    }
}
