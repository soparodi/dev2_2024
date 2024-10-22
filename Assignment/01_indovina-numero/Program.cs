Random random = new Random(); 
int numeroDaIndovinare = random.Next(1, 51);
int tentativi = 10;
bool haIndovinato = false;


Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 50). Hai 10 tentativi: ");

while (!haIndovinato && tentativi < 10)

{
    Console.WriteLine("Tentativo {0}: ", tentativi - 1);

    int numeroInserito = Convert.ToInt32(Console.ReadLine());

    tentativi--;

    if (numeroInserito < numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' maggiore");
    }
    else if (numeroInserito > numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' minore");

        Console.WriteLine("Riprova: ");
    }
    else
    {
        Console.WriteLine("Hai indovinato");
        haIndovinato = true;
    }

    if (tentativi == 0 && !haIndovinato)
    {
        Console.WriteLine($"Hai finito i punti. Il numero da indovinare era: {numeroDaIndovinare}");
    }
}