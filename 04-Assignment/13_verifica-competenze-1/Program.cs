// Creo un menu per usare la rubrica
List<Dictionary<string, string>> rubrica = new List<Dictionary<string, string>>();

while (true)
{
    Console.WriteLine("\nSeleziona un'operazione:");
    Console.WriteLine("1 - Aggiungi un contatto");
    Console.WriteLine("2 - Visualizza tutti i contatti");
    Console.WriteLine("3 - Cerca un contatto per nome");
    Console.WriteLine("4 - Modifica un contatto per nome");
    Console.WriteLine("5 - Cancella un contatto per nome");
    Console.WriteLine("6 - Esci");

    string scelta = Console.ReadLine();

    // Uso uno switch per mettere insieme tutte le funzioni del menu
    switch (scelta)
    {
        case "1":
            AggiungiContatto(rubrica);
            break;
        case "2":
            VisualizzaContatti(rubrica);
            break;
        case "3":
            CercaContatto(rubrica);
            break;
        case "4":
            ModificaContatto(rubrica);
            break;
        case "5":
            CancellaContatto(rubrica);
            break;
        case "6":
            Console.WriteLine("Uscita dal programma.");
            return;
        default:
            Console.WriteLine("Scelta non valida. Riprova.");
            break;
    }
}

// Funzione per aggiungere un contatto alla rubrica
void AggiungiContatto(List<Dictionary<string, string>> rubrica)
{
    Console.WriteLine("Inserisci il nome:");
    string nome = Console.ReadLine();
    Console.WriteLine("Inserisci il cognome:");
    string cognome = Console.ReadLine();
    Console.WriteLine("Inserisci l'indirizzo:");
    string indirizzo = Console.ReadLine();
    Console.WriteLine("Inserisci il numero di telefono:");
    string numero = Console.ReadLine();

    Dictionary<string, string> contatto = new Dictionary<string, string>
        {
            { "Nome", nome },
            { "Cognome", cognome },
            { "Indirizzo", indirizzo },
            { "Numero", numero }
        };

    rubrica.Add(contatto);
    Console.WriteLine("Contatto aggiunto con successo.");
}

// Funzione per visualizzare tutti i contatti della rubrica
void VisualizzaContatti(List<Dictionary<string, string>> rubrica)
{
    if (rubrica.Count == 0)
    {
        Console.WriteLine("La rubrica è vuota.");
        return;
    }

    Console.WriteLine("\nRubrica:");
    foreach (var contatto in rubrica)
    {
        Console.WriteLine($"Nome: {contatto["Nome"]}, Cognome: {contatto["Cognome"]}, Indirizzo: {contatto["Indirizzo"]}, Numero: {contatto["Numero"]}");
    }
}

// Funzione per cercare un contatto per nome
void CercaContatto(List<Dictionary<string, string>> rubrica)
{
    Console.WriteLine("Inserisci il nome:");
    string nome = Console.ReadLine();

    bool trovato = false;
    foreach (var contatto in rubrica)
    {
        if (contatto["Nome"] == nome)
        {
            Console.WriteLine($"Nome: {contatto["Nome"]}, Cognome: {contatto["Cognome"]}, Indirizzo: {contatto["Indirizzo"]}, Numero: {contatto["Numero"]}");
            trovato = true;
        }
    }

    if (!trovato)
    {
        Console.WriteLine("Nessun contatto trovato.");
    }
}

// Funzione per modificare un contatto per nome
void ModificaContatto(List<Dictionary<string, string>> rubrica)
{
    Console.WriteLine("Inserisci il nome del contatto da modificare:");
    string nome = Console.ReadLine();

    bool trovato = false;
    foreach (var contatto in rubrica)
    {
        if (contatto["Nome"] == nome)
        {
            trovato = true;
            Console.WriteLine("Inserisci i dati:");
            Console.WriteLine($"Nome: {contatto["Nome"]}");
            string nuovoNome = Console.ReadLine();
            if (nuovoNome != null && nuovoNome != "") contatto["Nome"] = nuovoNome;

            Console.WriteLine($"Cognome: {contatto["Cognome"]}");
            string nuovoCognome = Console.ReadLine();
            if (nuovoCognome != null && nuovoCognome != "") contatto["Cognome"] = nuovoCognome;

            Console.WriteLine($"Indirizzo: {contatto["Indirizzo"]}");
            string nuovoIndirizzo = Console.ReadLine();
            if (nuovoIndirizzo != null && nuovoIndirizzo != "") contatto["Indirizzo"] = nuovoIndirizzo;

            Console.WriteLine($"Numero: {contatto["Numero"]}");
            string nuovoNumero = Console.ReadLine();
            if (nuovoNumero != null && nuovoNumero != "") contatto["Numero"] = nuovoNumero;

            Console.WriteLine("Contatto modificato.");
            break;
        }
    }

    if (!trovato)
    {
        Console.WriteLine("Contatto non trovato.");
    }
}

// Funzione per cancellare un contatto per nome
void CancellaContatto(List<Dictionary<string, string>> rubrica)
{
    Console.WriteLine("Inserisci il nome del contatto da cancellare:");
    string nome = Console.ReadLine();

    for (int i = 0; i < rubrica.Count; i++)
    {
        if (rubrica[i]["Nome"] == nome)
        {
            rubrica.RemoveAt(i);
            Console.WriteLine("Contatto cancellato.");
            return;
        }
    }

    Console.WriteLine("Contatto non trovato.");
}