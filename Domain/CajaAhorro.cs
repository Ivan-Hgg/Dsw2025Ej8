using Dsw2025Ej8.Domain.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

class CajaAhorro : CuentaBancaria
{
    public decimal TasaDeInteres {  get; init; }

    public CajaAhorro (string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
    {
    }
    //ya estaria, revisar el aplicar interes
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


    }

    public void AplicarInteres()
    {

        Saldo *=  TasaDeInteres;
        
    }
}
