using Dsw2025Ej8.Domain.Excepciones;
using System.Data;

namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; private set; }
    public decimal Comision { get; private set; }
    public string[] Titulares { get; }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        Numero = numero;
        Saldo = saldo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }
    public void Desactivar()
    {
        Estado = Estado.Inactiva;
    }

    public void Activar()
    {
        Estado = Estado.Activa;
    }

    public void Suspender()
    {
        Estado = Estado.Suspendida;
    }


    public void Depositar(decimal monto)
    {
        if (monto <=0)
        {
            throw new MontoNoValido();
        }
        if()
        
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += monto;
        }
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            monto -= monto * _comision;
            _saldo += monto;
        }
    }

    public void Retirar(decimal monto)
    { 
        if (monto <= 0)
        {
            throw new MontoNoValido();
        }

        /*if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo -= monto;
        }
        else if (_tipo == TipoCuenta.CuentaCorriente)
        {
            if (_saldo - monto >= -_limiteDeDescubierto)
            {
                _saldo -= monto;
            }
            if (_saldo < 0)
            {
                _estado = Estado.Suspendida;
            }*/
        }
    }

    public void AplicarInteres()
    {
        if (_tipo == TipoCuenta.CajaDeAhorro)
        {
            _saldo += _saldo * _tasaDeInteres;
        }
    }
}
