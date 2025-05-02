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


    public abstract void Depositar(decimal monto);

    public abstract void Retirar(decimal monto);
    
    

    
}
