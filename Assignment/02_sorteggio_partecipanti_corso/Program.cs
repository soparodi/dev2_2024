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