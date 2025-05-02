using Dsw2025Ej8.Domain.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

class CuentaCorriente: CuentaBancaria
{
    public decimal LimiteDeDescubierto { get; init; }

    public CuentaCorriente(string numoer, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
    {
    }

    //falta integrar bien el depositar y retirar
    public override void Depositar(decimal monto)
    {
        if (monto <= 0)
        {
            throw new MontoNoValido();
        }
        if (this.Estado != Estado.Activa)
        {
            throw new CuentaNoActiva(this.Estado);
        }
        this.Saldo += monto;
        /*
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            monto -= monto * _comision;
            _saldo += monto;
        }*/
    }


    public override void Retirar(decimal monto)
    {
        if (monto <= 0)
        {
            throw new MontoNoValido();
        }
        if (this.Estado != Estado.Activa)
        {
            throw new CuentaNoActiva(this.Estado);
        }
        if (this.Saldo < 0)
        {
            this.Suspender();
        }
        this.Saldo -= monto;

        /*
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            if (_saldo - monto >= -_limiteDeDescubierto)
            {
                _saldo -= monto;
            }
            */

    }


}
