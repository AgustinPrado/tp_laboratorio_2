using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
            : this("DNI INVALIDO")
        {

        }

        public DniInvalidoException(Exception e)
            : base("DNI INVALIDO", e)
        {
            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
        }

        public DniInvalidoException(string message)
            : base(message)
        {
            throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
        }

        public DniInvalidoException(string message, Exception e)
            : this(e)
        {
            
        }
    }
}
