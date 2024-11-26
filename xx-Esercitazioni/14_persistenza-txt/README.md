```csharp
// GESTIONE FILES TXT

// LEGGERE UN CONTENUTO DA UN FILE TXT

string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
string[] lines = File.ReadAllLines(path); // legge tutte le righe del programma e le mette in un array di stringhe
foreach (string line in lines)
{
    Console.WriteLine(line); // stampa la riga
}

string[] nomi = new string[lines.Length]; // crea un array di stringhe con la lunghezza del numero di righe del file
for (int i = 0; < lines.Length; i++)
{
    nomi[i] = lines[i]; // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
}
foreach (string nome in nomi)
{
    Console.WriteLine(nome); // stampa la riga
}

// LEGGERE UN CONTENUTO E STAMPARE SOLO LE RIGHE CHE INIZIANO CON UNA DETERMINATA LETTERA

// string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
// string[] lines = File.ReadAllLines(path); // legge tutte le righe del programma e le mette in un array di stringhe
foreach (string line in lines)
{
    if (line.StartsWith("n")) // controlla se la riga inizia con una determinata lettera
    {
        Console.WriteLine(line); // stampa la riga
    }
}

// se nessun nome inizia con la lettera scelta, dà un messaggio di errore
foreach (string line in lines)
{
    if (line.StartsWith("n")) // controlla se la riga inizia con una determinata lettera
    {
        Console.WriteLine(line); // stampa la riga
    }
    else
    {
        Console.WriteLine("NOT FOUND");
    }
}


```

## Esempi:

## 1
- "not found" ad ogni riga
```csharp
string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
string[] lines = File.ReadAllLines(path); // legge tutte le righe del programma e le mette in un array di stringhe
foreach (string line in lines)
{
    if (line.StartsWith("s")) // controlla se la riga inizia con una determinata lettera
    {
        Console.WriteLine(line); // stampa la riga
    }
    else
    {
        Console.WriteLine("NOT FOUND");
    }
}
```

- stampare "not found" una volta sola o ricerca mirata

## 2

```csharp
string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
string[] lines = File.ReadAllLines(path); // legge tutte le righe del programma e le mette in un array di stringhe

bool nessunNomeCon = true;

foreach (string line in lines)
{
    if (line.StartsWith("S")) // controlla se la riga inizia con una determinata lettera
    {
        Console.WriteLine(line); // stampa la riga
        nessunNomeCon = false;
    }
}

if (nessunNomeCon)
{
    Console.WriteLine("NOT FOUND");
}
```

