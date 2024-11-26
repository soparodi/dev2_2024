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

string path2 = @"testOutput.txt";
File.CreateText(path2).Close();

foreach (string line in lines)
{
    if (line.StartsWith("S")) // controlla se la riga inizia con una determinata lettera
    {
        // Console.WriteLine(line);
        nessunNomeCon = false; // se trovo un nome che inizia con la lettera, il booleano diventa falso
        File.AppendAllText(path2, line + "\n"); // scrive la riga nel file di output andando a capo
    }
}

if (nessunNomeCon)
{
    Console.WriteLine("NOT FOUND");
}

// AGGIUNGERE UNA RIGA DI TESTO IN UNA POSIZIONE SPECIFICA

// stampo la lunghezza dell'array
Console.WriteLine(lines.Length);
lines[lines.Length - 1] += "INDIRIZZO"; // aggiunge indirizzo alla penultima riga
File.WriteAllLines(path2, lines); // scrive tutte le righe nel file

// AGGIUNGERE UNA RIGA IN UNA POSIZIONE SPECIFICA USANDO ACCENTO CIRCONFLESSO

lines[^1] = "\n TELEFONO"; // aggiunge indirizzo alla penultima riga
File.WriteAllLines(path2, lines); // scrive tutte le righe nel file
