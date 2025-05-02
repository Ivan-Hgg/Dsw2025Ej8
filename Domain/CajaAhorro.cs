using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

class CajaAhorro
{
    public decimal TasaDeInteres {  get; init; }

    public CajaAhorro (string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
    {
    }
}
