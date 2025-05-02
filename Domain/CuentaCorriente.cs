using Dsw2025Ej8.Domain.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;


public class CuentaCorriente : CuentaBancaria
{
    public decimal LimiteDeDescubierto { get; init; }

    public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares) { }

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
        if (Saldo + LimiteDeDescubierto < monto)
        {
            Saldo = -LimiteDeDescubierto;
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
        monto -= monto * Comision;
        Saldo += monto;
    }
}