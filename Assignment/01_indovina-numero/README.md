# INDOVINA NUMERO

## Obiettivo

L'obiettivo di questa applicazione è di indovinare un **numero casuale** generato dal computer.

> Passaggi:

1. Il computer genera un numero casuale tra 1 e 100

```csharp
Random random = new Random(); 

int numeroDaIndovinare = random.Next(1, 101);

Console.WriteLine("Indovina il numero (tra 1 e 100)");

int numeroInserito;

numeroInserito = Convert.ToInt32(Console.ReadLine()); 

if (numeroInserito == numeroDaIndovinare)

{
    Console.WriteLine("Complimenti, hai indovinato il numero!");
}
else
{
    Console.WriteLine("Mi dispiace, non hai indovinato il numero");

    Console.WriteLine($"Il numero da indovinare era: {numeroDaIndovinare}");
}
```