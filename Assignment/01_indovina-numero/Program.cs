Random random = new Random(); // Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101); // Next e il metodo che genera un numero casuale tra 1 e 100
int tentativiMassimi = 5;
int tentativiEffettuati = 0;
bool haIndovinato = false;
// int numeroInserito = 0;

Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 100). Hai 5 tentativi: ");

while (tentativiEffettuati < tentativiMassimi && !haIndovinato)
{
    Console.WriteLine("Tentativo {0}: ", tentativiEffettuati + 1);

    int numeroInserito = Convert.ToInt32(Console.ReadLine());

    tentativiEffettuati++;

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
    }

    if (tentativiEffettuati == tentativiMassimi && !haIndovinato)
    {
        Console.WriteLine($"Hai finito i tentativi. Il numero da indovinare era: {numeroDaIndovinare}");
    }
}