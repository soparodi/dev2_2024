# Sorteggio partecipanti

## Versione 1

## Obiettivo

- Scrivere un programma che permetta di sorteggiare i partecipanti del corso da una lista di nomi.
- I nomi vengono gestiti senza un inserimento da parte dell utente cioe vengono inzializzati nel programma.
- Il programma estrae un partecipante singolo alla volta e lo stampa a video.

```csharp
string[] partecipanti = new string[] { "Partecipante 1", "Partecipante 2", "Partecipante 3" };

Random random = new Random();
int index = random.Next(partecipanti.Length);
string partecipante = partecipanti[index];
Console.WriteLine(partecipante);
```

## Comandi di versionamento

```bash
git add --all
git commit -m "Sorteggia Partecipanti Versione 1"
git push -u origin main
```

## Versione 2

```csharp
// Creo la lista dei partecipanti
List<string> partecipanti = new List<string>
{
    "Adalgisa",
    "Maria",
    "Roberto",
};

// Creo un oggetto Random per generare il sorteggio
Random random = new Random();

// Ciclo finché ci sono nomi nella lista
while (partecipanti.Count > 0)
{
    // Estraggo un indice casuale nella lista
    int index = random.Next(partecipanti.Count);

    // Seleziono il nome dalla lista in base all'indice estratto
    string partecipanteEstratto = partecipanti[index];

    // Stampo il nome estratto
    Console.WriteLine($"Il partecipante estratto è: {partecipanteEstratto}");

    // Rimuovo il partecipante estratto dalla lista
    partecipanti.RemoveAt(index);

    // Controllo se ci sono ancora partecipanti nella lista
    if (partecipanti.Count == 0)
    {
        Console.WriteLine("Tutti i partecipanti sono stati estratti.");
        break;
    }

    // Chiedo all'utente se vuole continuare
    Console.Write("Vuoi estrarre un altro partecipante? (s/n): ");
    string risposta = Console.ReadLine().ToLower();

    if (risposta != "s")
    {
        Console.WriteLine("Estrazione terminata dall'utente.");
        break;
    }
}
```
