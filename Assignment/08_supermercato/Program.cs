// Lista dei prodotti disponibili nel supermercato
List<string> prodottiSupermercato = new List<string> { "mela", "banana", "pasta", "pane", "latte" };
Console.Clear();
// Dizionario per i prezzi dei prodotti
Dictionary<string, double> prezziProdotti = new Dictionary<string, double>
{
    { "mela", 0.5 },
    { "banana", 0.3 },
    { "pasta", 1.2 },
    { "pane", 1.0 },
    { "latte", 1.5 }
};

// Dizionario per il carrello (nome prodotto - quantità)
Dictionary<string, int> carrello = new Dictionary<string, int>();

bool continua = true;

while (continua)
{
    Console.WriteLine("\na. Visualizza prodotti");
    Console.WriteLine("b. Aggiungi prodotto");
    Console.WriteLine("c. Visualizza carrello");
    Console.WriteLine("d. Rimuovi prodotto");
    Console.WriteLine("e. Effettua pagamento");
    Console.WriteLine("f. Esci");
    Console.Write("Inserisci la tua scelta: ");
   
    string scelta = Console.ReadLine();
    Console.Clear();

    switch (scelta)
    {
        case "a":
            VisualizzaProdotti(prodottiSupermercato, prezziProdotti);
            break;

        case "b":
            AggiungiProdotto(carrello, prodottiSupermercato);
            break;

        case "c":
            VisualizzaCarrello(carrello, prezziProdotti);
            break;

        case "d":
            RimuoviProdotto(carrello);
            break;

        case "e":
            EffettuaPagamento(carrello, prezziProdotti);
            continua = false;
            break;

        case "f":
            Console.WriteLine("Grazie e arrivederci!");
            continua = false;
            break;

        default:
            Console.WriteLine("Scelta non valida. Riprova.");
            break;
    }
}

// Funzione per visualizzare i prodotti disponibili e i loro prezzi
void VisualizzaProdotti(List<string> prodotti, Dictionary<string, double> prezziProdotti)
{
    Console.WriteLine("Prodotti disponibili:");
    for (int i = 0; i < prodotti.Count; i++)
    {
        string prodotto = prodotti[i];
        Console.WriteLine($"{i + 1}. {prodotto} - Prezzo: {prezziProdotti[prodotto]:C}");
    }
}

// Funzione per aggiungere un prodotto al carrello
void AggiungiProdotto(Dictionary<string, int> carrello, List<string> prodottiSupermercato)
{
    Console.WriteLine("Quale prodotto vuoi aggiungere? Inserisci un numero da questo elenco:");
    VisualizzaProdotti(prodottiSupermercato, prezziProdotti);

    if (int.TryParse(Console.ReadLine(), out int scelta) && scelta > 0 && scelta <= prodottiSupermercato.Count)
    {
        string prodotto = prodottiSupermercato[scelta - 1];
        Console.Write("Quantità: ");
       
        if (int.TryParse(Console.ReadLine(), out int quantita) && quantita > 0)
        {
            if (carrello.ContainsKey(prodotto))
            {
                carrello[prodotto] += quantita;
            }
            else
            {
                carrello[prodotto] = quantita;
            }
            Console.WriteLine($"{quantita} x {prodotto} aggiunto al carrello.\n");
        }
        else
        {
            Console.WriteLine("Quantità non valida.");
        }
    }
    else
    {
        Console.WriteLine("Prodotto non valido.");
    }
}

// Funzione per visualizzare il contenuto del carrello con i prezzi
void VisualizzaCarrello(Dictionary<string, int> carrello, Dictionary<string, double> prezziProdotti)
{
    Console.WriteLine("Carrello:");
    if (carrello.Count == 0)
    {
        Console.WriteLine("Il carrello è vuoto.\n");
    }
    else
    {
        foreach (var item in carrello)
        {
            string prodotto = item.Key;
            int quantita = item.Value;
            double prezzo = prezziProdotti[prodotto];
            Console.WriteLine($"{quantita} x {prodotto} - Prezzo unitario: {prezzo:C} - Totale: {(quantita * prezzo):C}");
        }

        // Calcola e mostra il totale
        double totale = CalcolaTotale(carrello, prezziProdotti);
        Console.WriteLine($"\nTotale Carrello: {totale:C}");
    }
}

// Funzione per rimuovere un prodotto dal carrello
void RimuoviProdotto(Dictionary<string, int> carrello)
{
    Console.WriteLine("Quale prodotto vuoi rimuovere? Inserisci il nome del prodotto:");

    if (carrello.Count == 0)
    {
        Console.WriteLine("Il carrello è vuoto. Nessun prodotto da rimuovere.\n");
        return;
    }

    foreach (var item in carrello)
    {
        Console.WriteLine($"{item.Key} - Quantità: {item.Value}");
    }

    string prodotto = Console.ReadLine();

    if (carrello.ContainsKey(prodotto))
    {
        Console.Write("Quantità da rimuovere: ");
        if (int.TryParse(Console.ReadLine(), out int quantitaDaRimuovere) && quantitaDaRimuovere > 0)
        {
            if (carrello[prodotto] > quantitaDaRimuovere)
            {
                carrello[prodotto] -= quantitaDaRimuovere;
                Console.WriteLine($"{quantitaDaRimuovere} x {prodotto} rimosso dal carrello.\n");
            }
            else
            {
                carrello.Remove(prodotto);
                Console.WriteLine($"{prodotto} articolo rimosso dal carrello.\n");
            }
        }
        else
        {
            Console.WriteLine("Quantità non valida");
        }
    }
    else
    {
        Console.WriteLine("Prodotto non trovato nel carrello");
    }
}

// Funzione per calcolare il totale del carrello
double CalcolaTotale(Dictionary<string, int> carrello, Dictionary<string, double> prezziProdotti)
{
    double totale = 0;
    foreach (var item in carrello)
    {
        string prodotto = item.Key;
        int quantita = item.Value;
        double prezzo = prezziProdotti[prodotto];
        totale += quantita * prezzo;
    }
    return totale;
}

// Funzione per effettuare il pagamento
void EffettuaPagamento(Dictionary<string, int> carrello, Dictionary<string, double> prezziProdotti)
{
    Console.WriteLine("---Pagamento---\n");
    if (carrello.Count == 0)
    {
        Console.WriteLine("Il carrello è vuoto. Niente da pagare.");
    }
    else
    {
        double totale = CalcolaTotale(carrello, prezziProdotti);
        Console.WriteLine($"Il totale da pagare è: {totale:C}");
        Console.WriteLine("Grazie per aver effettuato l'acquisto!");
    }
}