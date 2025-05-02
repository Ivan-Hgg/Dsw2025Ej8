using Dsw2025Ej8.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CuentaNoActiva : Exception
{
    public CuentaNoActiva(CuentaBancaria x) : base($"La cuenta {x.Numero} esta {x.Estado}") { }
}
