using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinInstructorException : Exception
    {
        /// <summary>
        /// Constructor por defecto que pasa un mensaje fijo al base.
        /// </summary>
        public SinInstructorException()
            : base("No hay instructor para la clase.")
        {

        }
    }
}
