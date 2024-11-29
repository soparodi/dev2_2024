## SORTEGGIO PARTECIPANTI CON FUNZIONI

# Versione 1

# Obiettivo:

- Creo una funzione per richiedere il numero di squadre
- Creo una funzione per ottenere un dizionario di squadre vuote
- Creo una funzione per distribuire i partecipanti nelle squadre
- Creo una funzione per aggiungere un partecipante casuale a una squadra
- Creo una funzione per stampare le squadre e i loro partecipanti


```csharp
List<string> partecipanti = new List<string>
    {
        "Partecipante 1", "Partecipante 2", "Partecipante 3", "Partecipante 4", "Partecipante 5",
        "Partecipante 6", "Partecipante 7", "Partecipante 8", "Partecipante 9", "Partecipante 10"
    };
Dictionary<int, List<string>> squadre;

int numeroSquadre = ChiediNumeroSquadre();
CreaSquadre(numeroSquadre);
DistribuisciPartecipanti();
StampaSquadre();


// Creo una funzione per richiedere il numero di squadre
int ChiediNumeroSquadre()
{
    Console.WriteLine("Inserisci il numero di squadre: ");
    return int.Parse(Console.ReadLine());
}

// Creo una funzione per ottenere un dizionario di squadre vuote
void CreaSquadre(int numeroSquadre)
{
    squadre = new Dictionary<int, List<string>>();
    for (int i = 0; i < numeroSquadre; i++)
    {
        squadre.Add(i + 1, new List<string>());
    }
}

// Creo una funzione per distribuire i partecipanti nelle squadre
void DistribuisciPartecipanti()
{
    Random random = new Random();
    int numeroSquadre = squadre.Count;
    int partecipantiPerSquadra = partecipanti.Count / numeroSquadre;
    int partecipantiInPiu = partecipanti.Count % numeroSquadre;

    // Distribuisco i partecipanti in modo uniforme
    for (int i = 0; i < numeroSquadre; i++)
    {
        for (int j = 0; j < partecipantiPerSquadra; j++)
        {
            RiassegnaPartecipante(squadre[i + 1], random);
        }

        // Assegno eventuali partecipanti extra
        if (partecipantiInPiu > 0)
        {
            RiassegnaPartecipante(squadre[i + 1], random);
            partecipantiInPiu--;
        }
    }
}

// Creo una funzione per aggiungere un partecipante casuale a una squadra
void RiassegnaPartecipante(List<string> squadra, Random random)
{
    int index = random.Next(partecipanti.Count);
    squadra.Add(partecipanti[index]);
    partecipanti.RemoveAt(index);
}

// Creo una funzione per stampare le squadre e i loro partecipanti
void StampaSquadre()
{
    foreach (var squadra in squadre)
    {
        Console.WriteLine($"Squadra {i + 1}:");
        foreach (string partecipante in squadre[i + 1])
        {
            Console.WriteLine(partecipante);
        }
        Console.WriteLine();
    }
}
```