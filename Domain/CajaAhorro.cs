using Dsw2025Ej8.Domain.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class CajaDeAhorro : CuentaBancaria
{
    public decimal TasaDeInteres { get; init; }

    public CajaDeAhorro(string numero, decimal saldo, string[] titulares)
        : base(numero, saldo, titulares)
    {
    }

    public void AplicarInteres()
    {
        Saldo += Saldo * TasaDeInteres;
    }

    public override void Retirar(decimal monto)
    {
        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActiva(this);
        }
        if (monto <= 0)
        {
            throw new MontoNoValido();
        }
        if (Saldo - monto < 0)
        {
            base.Suspender();
            throw new SaldoInsuficiente();
        }
        Saldo -= monto;
    }

    public override void Depositar(decimal monto)
    {
        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActiva(this);
        }
        if (monto <= 0)
        {
            throw new MontoNoValido();
        }

        Saldo += monto;
    }
}
