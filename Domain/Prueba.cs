using Dsw2025Ej8.Domain.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public static class Prueba
{
    public static string[] Titulares =
    {
        "Facu",
        "Tadeo",
        "Ivan"
    };
    public static List<CuentaBancaria> Cuentas { get; private set; } = new List<CuentaBancaria>();

    public static void GuardarDatos()
    {
        // Para el número de cuenta, el primer dígito es el número de posición en el array
        // y el segundo dígito es el tipo de cuenta: ahorro = 1 y corriente = 2
        CajaDeAhorro cuentaAhorro1 = new("01", 1000, Titulares)
        {
            TasaDeInteres = 0.05m
        };
        CajaDeAhorro cuentaAhorro2 = new("11", 500, Titulares)
        {
            TasaDeInteres = 1.0m
        };
        CuentaCorriente cuentaCorriente1 = new("22", 2000, Titulares)
        {
            LimiteDeDescubierto = 500
        };
        CuentaCorriente cuentaCorriente2 = new("32", -500, Titulares)
        {
            LimiteDeDescubierto = 1000
        };

        Cuentas.Add(cuentaAhorro1);
        Cuentas.Add(cuentaAhorro2);
        Cuentas.Add(cuentaCorriente1);
        Cuentas.Add(cuentaCorriente2);

        Pruebita();
    }

    public static void FalloActiva()
    {
        Cuentas[3].Desactivar();
        System.Threading.Thread.Sleep(3000);
        try
        {
            Cuentas[3].Depositar(500);
        }
        catch (CuentaNoActiva ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (MontoNoValido ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (SaldoInsuficiente ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void Deposito()
    {
        try
        {
            Console.WriteLine($"Saldo de la cuenta {Cuentas[1].Numero} es ${Cuentas[1].Saldo}");
            Cuentas[1].Depositar(500);
            Console.WriteLine($"Se depositaron $500");
            Console.WriteLine($"Saldo de la cuenta {Cuentas[1].Numero} es ${Cuentas[1].Saldo}");
            Console.WriteLine("En tres segundo intentara depositar monto = -1");
            System.Threading.Thread.Sleep(3000);
            Cuentas[1].Depositar(-1);
        }
        catch (CuentaNoActiva ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (MontoNoValido ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (SaldoInsuficiente ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void Retiro()
    {
        try
        {
            Console.WriteLine($"Saldo de la cuenta {Cuentas[1].Numero}  es  ${Cuentas[1].Saldo}");
            Cuentas[1].Retirar(1000);
            Console.WriteLine($"Se retiraron $1000");
            Console.WriteLine($"Saldo de la cuenta {Cuentas[1].Numero}  es  ${Cuentas[1].Saldo}");
            Console.WriteLine("En tres segundo se intentara retirar 500 mas");
            System.Threading.Thread.Sleep(3000);
            Cuentas[1].Retirar(500);
        }
        catch (CuentaNoActiva ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (MontoNoValido ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (SaldoInsuficiente ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void RetiroDescubierto()
    {
        try
        {
            Console.WriteLine($"Saldo de la cuenta {Cuentas[2].Numero}  es  ${Cuentas[2].Saldo}");
            Cuentas[2].Retirar(2001);
            Console.WriteLine($"Se retiraron $2001");
            Console.WriteLine($"Saldo de la cuenta {Cuentas[2].Numero}  es  ${Cuentas[2].Saldo}");
            Console.WriteLine("En tres segundo se intentara retirar 500 mas");
            System.Threading.Thread.Sleep(3000);
            Cuentas[2].Retirar(500);
        }
        catch (CuentaNoActiva ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (MontoNoValido ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (SaldoInsuficiente ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void Interes()
    {
        try
        {
            if (Cuentas[0] is CajaDeAhorro cuentaAhorro)
            {
                Console.WriteLine($"Saldo de la cuenta {cuentaAhorro.Numero} es ${cuentaAhorro.Saldo}");
                cuentaAhorro.AplicarInteres();
                Console.WriteLine("Se aplico el interes");
                Console.WriteLine($"Saldo de la cuenta {cuentaAhorro.Numero}  es  ${cuentaAhorro.Saldo}");
            }
        }
        catch (CuentaNoActiva ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (MontoNoValido ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (SaldoInsuficiente ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void Pruebita()
    {
        Console.WriteLine("Prueba de excepciones");
        Mostrar();
        Console.WriteLine("Prueba 1: Cuenta Activa-Inactiva");
        FalloActiva();

        Console.WriteLine("");
        Console.WriteLine("Prueba 2: Deposito");
        Deposito();

        Console.WriteLine("");
        Console.WriteLine("Prueba 3: Retiro");
        Retiro() ;

        Console.WriteLine("");
        Console.WriteLine("Prueba 4: Retiro Descubierto");
        RetiroDescubierto();
       

        Console.WriteLine("");
        Console.WriteLine("Prueba 5: Interes");
        Interes();

        Console.WriteLine("");
        Console.WriteLine("Fin de las pruebas");
        Mostrar();
        
        Console.WriteLine("Presione cualquier tecla para terminar...");
        Console.ReadKey();
    }

    public static void Mostrar()
    {
        Console.WriteLine("Estado actual de las cuentas:");
        foreach (var cuenta in Cuentas)
        {
            Console.WriteLine($"Cuenta {cuenta.Numero}, Saldo: ${cuenta.Saldo}, Estado: {cuenta.Estado}");
        }
        Console.WriteLine("");
    }
}
