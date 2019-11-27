using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMasGlobal.Model.Exceptions
{
    /// <summary>
    /// Representa los errores que se generan durante las validaciones
    /// </summary>
    [Serializable]
    public class ApiException : Exception
    {
        /// <summary>
        /// Inicializa una instancia de la clase ExcepcionValidacion
        /// </summary>
        public ApiException()
        {
        }

        /// <summary>
        /// Inicializa una instancia de la clase ExcepcionValidacion con el mensaje de error especificado
        /// </summary>
        public ApiException(string mensaje)
            : base(mensaje)
        {
        }
    }
}
