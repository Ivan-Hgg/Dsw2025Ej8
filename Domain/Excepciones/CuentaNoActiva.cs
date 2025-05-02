using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain.Excepciones
{
    internal class CuentaNoActiva : Exception
    {
        public CuentaNoActiva(Estado e) : base($"No se puede operar con la cuenta {e}") { }
    }
}
