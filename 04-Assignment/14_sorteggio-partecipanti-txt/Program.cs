// Percorso del file di input
string path = @"test.txt";

// Creazione del file e inserimento dei nomi
string[] lines = new string[5]; // Inizializzo un array di 5 elementi
lines[^5] = "Teresa"; // Inserisco i nomi negli indici appropriati
lines[^4] = "Oreste";
lines[^3] = "Adalgisa";
lines[^2] = "Erasto";
lines[^1] = "Egle";

// Scrivo i nomi nel file
File.WriteAllLines(path, lines);

// Leggo i nomi dal file di input
List<string> nomi = new List<string>(File.ReadAllLines(path));

if (nomi.Count == 0)
{
    Console.WriteLine("Il file 'test.txt' è vuoto.");
    return;
}

// Chiedo all'utente quanti nomi sorteggiare
Console.Write("Quanti nomi vuoi sorteggiare? ");
if (!int.TryParse(Console.ReadLine(), out int numeroSorteggi) || numeroSorteggi <= 0)
{
    Console.WriteLine("Inserisci un numero valido maggiore di 0.");
    return;
}

if (numeroSorteggi > nomi.Count)
{
    Console.WriteLine("Non ci sono abbastanza nomi nella lista.");
    return;
}

// Sorteggio i nomi
Random random = new Random();
List<string> nomiSorteggiati = new List<string>();
while (nomiSorteggiati.Count < numeroSorteggi)
{
    int index = random.Next(nomi.Count);
    string nome = nomi[index];
    if (!nomiSorteggiati.Contains(nome)) // Evita duplicati
    {
        nomiSorteggiati.Add(nome);
    }
}

// Scrivo i nomi sorteggiati in un file di output
string outputFilePath = "output.txt";
File.WriteAllLines(outputFilePath, nomiSorteggiati);

Console.WriteLine($"I nomi sorteggiati sono stati salvati in '{outputFilePath}':");
foreach (string nome in nomiSorteggiati)
{
    Console.WriteLine(nome);
}