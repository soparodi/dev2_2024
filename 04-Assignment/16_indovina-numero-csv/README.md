# Indovina numero csv

## Obiettivo

- Implementare la persistenza dei dati in un file CSV unico tra tutti i giocatori chiamato partiteSalvate.csv
- Il file conterra le colonne: nomegiocatore, punteggio, numerotentativi

## Versione precedente che usa i file txt:

Program.cs completo:

```csharp
Console.Clear();
Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;
string nomeUtente = "";
string risposta = "s";

Dictionary<string, List<int>> tentativiUtenti = new Dictionary<string, List<int>>(); // creo un dizionario per memorizzare i tentativi degli utenti

do
{
    int scelta = ScegliDifficolta();

    switch (scelta)
    {
        case 1:
            numeroDaIndovinare = GeneraNumeroCasuale(1, 51);
            punteggio = 100;
            tentativi = 10;
            break;
        case 2:
            numeroDaIndovinare = GeneraNumeroCasuale(1, 101);
            punteggio = 200;
            tentativi = 7;
            break;
        case 3:
            numeroDaIndovinare = GeneraNumeroCasuale(1, 201);
            punteggio = 300;
            tentativi = 5;
            break;
        default:
            Console.WriteLine("Scelta non valida.");
            break;
    }

    ChiediNomeUtente(tentativiUtenti, ref nomeUtente);

    IndovinaNumero(numeroDaIndovinare, tentativi, punteggio, tentativiUtenti, nomeUtente);

    StampaTentativi(tentativiUtenti, nomeUtente);

    GiocaAncora(ref risposta);

    haIndovinato = false;

} while (risposta == "s" || risposta == "S");


static void ScriviTentativiSuFile(Dictionary<string, List<int>> tentativiUtenti, string nomeUtente)
{
using (StreamWriter sw = new StreamWriter($"{nomeUtente}.txt"))
{
    foreach (var tentativoUtente in tentativiUtenti)
    {
        if (tentativoUtente.Key == nomeUtente)
        {
            sw.WriteLine($"{tentativoUtente.Key}: {string.Join(", ", tentativoUtente.Value)}");
        }
    }
}
}

static void StampaTentativi(Dictionary<string, List<int>> tentativiUtenti, string nomeUtente)
{
Console.WriteLine("Tentativi effettuati: ");

foreach (var tentativoUtente in tentativiUtenti)
{
    if (tentativoUtente.Key == nomeUtente)
    {
        Console.WriteLine($"{tentativoUtente.Key}: {string.Join(", ", tentativoUtente.Value)}"); // stampo i tentativi degli utenti
    }
}
}

static void ChiediNomeUtente(Dictionary<string, List<int>> tentativiUtenti, ref string nomeUtente)
{
Console.WriteLine("Inserisci il tuo nome:");
nomeUtente = Console.ReadLine();
}

static void GiocaAncora(ref string risposta)
{
Console.WriteLine("Vuoi giocare di nuovo? (s/n)");

risposta = Console.ReadLine();

Console.Clear();

while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
{
    Console.WriteLine("Risposta non valida. Vuoi giocare di nuovo? (s/n)");
    risposta = Console.ReadLine();
    Console.Clear();
}
}

void IndovinaNumero(int numeroDaIndovinare, int tentativi, int punteggio, Dictionary<string, List<int>> tentativiUtenti, string nomeUtente)
{
Console.WriteLine("Indovina il numero. Punteggio massimo: 100 punti.");

while (!haIndovinato && tentativi > 0)
{
    Console.Write("Tentativo: ");
    bool successo = int.TryParse(Console.ReadLine(), out int numeroUtente);
    // pulisco la console
    Console.Clear();

    if (!successo)
    {
        Console.WriteLine("Inserisci un numero valido.");
        continue;
    }

    tentativi--;
    // aggiungo il tentativo alla lista del nomeUtente
    if (!tentativiUtenti.ContainsKey(nomeUtente))
    {
        tentativiUtenti.Add(nomeUtente, new List<int>());
    }

    tentativiUtenti[nomeUtente].Add(numeroUtente); // aggiungo il tentativo alla lista del nomeUtente uso [nomeUtente] per accedere alla lista del nomeUtente

    if (numeroUtente < numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' maggiore.");
    }
    else if (numeroUtente > numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' minore.");
    }
    else
    {
        Console.WriteLine($"Hai indovinato! Punteggio: {punteggio}");
        haIndovinato = true;
    }

    if (!haIndovinato && tentativi == 0)
    {
        Console.WriteLine($"Hai esaurito i tentativi. Il numero era {numeroDaIndovinare}.");
    }

}

if (haIndovinato)
{
    // stampa il punteggio dell utente
    Console.WriteLine($"Punteggio: {punteggio}");
}

ScriviTentativiSuFile(tentativiUtenti, nomeUtente);
}

static int ScegliDifficolta()
{
int scelta = 0;

do
{
    Console.WriteLine("Scegli il livello di difficolta':");
    Console.WriteLine("1. Facile (1-50, 10 tentativi)");
    Console.WriteLine("2. Medio (1-100, 7 tentativi)");
    Console.WriteLine("3. Difficile (1-200, 5 tentativi)");

    bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta);
    // pulisco la console
    Console.Clear();
    if (!successoLivelloDifficolta || scelta < 1 || scelta > 3)
    {
        Console.WriteLine("Scelta non valida.");
    }
} while (scelta < 1 || scelta > 3);

return scelta;
}

static int GeneraNumeroCasuale(int min, int max)
{
return new Random().Next(min, max);
}
```

## Versione 1 con uso di csv

In modo da implementare la persistenza dei dati in un file CSV unico tra tutti i giocatori chiamato partiteSalvate.csv, dobbiamo modificare il codice in modo che i dati vengano scritti in un file CSV.

In dettaglio, dobbiamo modificare il metodo ScriviTentativiSuFile in modo che scriva i dati in un file CSV.

```csharp
static void ScriviTentativiSuFile(Dictionary<string, List<int>> tentativiUtenti, string nomeUtente)
{
using (StreamWriter sw = new StreamWriter("partiteSalvate.csv", true))
{
    foreach (var tentativoUtente in tentativiUtenti)
    {
        if (tentativoUtente.Key == nomeUtente)
        {
            sw.WriteLine($"{tentativoUtente.Key}, {string.Join(", ", tentativoUtente.Value)}");
        }
    }
}
}
```

La funzione indovinanumero non puo essere static in quanto accede a variabili di istanza. Quindi, dobbiamo creare una classe Game con un metodo IndovinaNumero.
Le differenze principali sono che ora il metodo IndovinaNumero accetta un oggetto StreamWriter come parametro e scrive i dati nel file CSV.

```csharp
In questo modo, i dati verranno scritti in un file CSV chiamato partiteSalvate.csv.