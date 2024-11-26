// Leggo i nomi da un file di input
string inputFilePath = "test.txt";
if (!File.Exists(inputFilePath))
{
    Console.WriteLine("Il file 'test.txt' non esiste.");
    return;
}

List<string> nomi = new List<string>(File.ReadAllLines(inputFilePath));

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