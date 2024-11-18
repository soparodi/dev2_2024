## SUPERMERCATO

## Versione 1

- Creo una lista di prodotti del supermercato
- Creo un dizionario (*string, int*)
- Creo una variabile booleana per controllare se il programma deve continuare
- Ciclo while loop per far funzionare il continua (menu che si vede finché il cliente non decide di uscire)
- Chiedere all'utente di inserire la sua scelta (*scelta*)
- Creo uno switch per eseguire la funzione (*case*: visualizza prod, aggiungi prod, ecc. + *end point* - es. pagamento + *default* - se l'utente sceglie un'opzione non valida)
- Chiudo il carrello e inzio il programma

```csharp
List<string> prodottiSupermercato = new List<string> { "Mela", "Banana", "Pasta", "Pane", "Latte\n" };
Console.Clear();
        // Dizionario per il carrello (Nome prodotto, Quantità)
        Dictionary<string, int> carrello = new Dictionary<string, int>();

        // Variabile booleana per controllare se il programma deve continuare
        bool continua = true;

        // Ciclo per far funzionare il "continua"
        while (continua)
        {
            // Mostra il menu e richiede la scelta dell'utente
            Console.WriteLine("a. Visualizza prodotti");
            Console.WriteLine("b. Aggiungi prodotto");
            Console.WriteLine("c. Visualizza carrello");
            Console.WriteLine("d. Effettua pagamento");
            Console.WriteLine("e. Esci");
            Console.Write("Inserisci la tua scelta: ");
           
            string scelta = Console.ReadLine();

Console.Clear();

            // Switch per gestire le diverse opzioni
            switch (scelta)
            {
                case "a":
                    VisualizzaProdotti(prodottiSupermercato);
                    break;

                case "b":
                    AggiungiProdotto(carrello, prodottiSupermercato);
                    break;

                case "c":
                    VisualizzaCarrello(carrello);
                    break;

                case "d":
                    EffettuaPagamento(carrello);
                    continua = false; // Fine del programma dopo il pagamento
                    break;

                case "e":
                    Console.WriteLine("Grazie e arrivederci!");
                    continua = false; // Esce dal loop
                    break;

                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }

    // Funzione per visualizzare i prodotti disponibili
    void VisualizzaProdotti(List<string> prodotti)
    {
        Console.WriteLine("Prodotti disponibili:");
        for (int i = 0; i < prodotti.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {prodotti[i]}");
        }
    }

    // Funzione per aggiungere un prodotto al carrello
    void AggiungiProdotto(Dictionary<string, int> carrello, List<string> prodottiSupermercato)
    {
        Console.WriteLine("Quale prodotto vuoi aggiungere? Inserisci il numero corrispondente:");
        VisualizzaProdotti(prodottiSupermercato);

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

    // Funzione per visualizzare il contenuto del carrello
   void VisualizzaCarrello(Dictionary<string, int> carrello)
    {
        Console.WriteLine("Carrello:");
        if (carrello.Count == 0)
        {
            Console.WriteLine("Il carrello è vuoto.\n");
        }
        else
        {
            foreach (var cibo in carrello)
            {
                Console.WriteLine($"{cibo.Value} x {cibo.Key}\n");
            }
        }
    }

    // Funzione per effettuare il pagamento
    void EffettuaPagamento(Dictionary<string, int> carrello)
    {
        Console.WriteLine("---Pagamento---\n");
        if (carrello.Count == 0)
        {
            Console.WriteLine("Il carrello è vuoto. Niente da pagare.");
        }
        else
        {
            Console.WriteLine("Grazie per aver effettuato l'acquisto!");
        }
    }
```

## Versione 2

- Rimuovo i prodotti dal carrello

```csharp
List<string> prodottiSupermercato = new List<string> { "Mela", "Banana", "Pasta", "Pane", "Latte\n" }; 
Dictionary<string, int> carrello = new Dictionary<string, int>();
bool continua = true;

while (continua)
{
    Console.WriteLine("a. Visualizza prodotti");
    Console.WriteLine("b. Aggiungi prodotto");
    Console.WriteLine("c. Visualizza carrello");
    Console.WriteLine("d. Rimuovi prodotto dal carrello");
    Console.WriteLine("e. Effettua pagamento");
    Console.WriteLine("f. Esci");
    Console.Write("Inserisci la tua scelta: ");
    
    string scelta = Console.ReadLine();
    Console.Clear();

    switch (scelta)
    {
        case "a":
            VisualizzaProdotti(prodottiSupermercato);
            break;

        case "b":
            AggiungiProdotto(carrello, prodottiSupermercato);
            break;

        case "c":
            VisualizzaCarrello(carrello);
            break;

        case "d":
            RimuoviProdotto(carrello);
            break;

        case "e":
            EffettuaPagamento(carrello);
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

void VisualizzaProdotti(List<string> prodotti)
{
    Console.WriteLine("Prodotti disponibili:");
    for (int i = 0; i < prodotti.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {prodotti[i]}");
    }
}

void AggiungiProdotto(Dictionary<string, int> carrello, List<string> prodottiSupermercato)
{
    Console.WriteLine("Quale prodotto vuoi aggiungere? Inserisci il numero corrispondente:");
    VisualizzaProdotti(prodottiSupermercato);

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

void VisualizzaCarrello(Dictionary<string, int> carrello)
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
            Console.WriteLine($"{item.Value} x {item.Key}\n");
        }
    }
}

void RimuoviProdotto(Dictionary<string, int> carrello)
{
    Console.WriteLine("Quale prodotto vuoi rimuovere? Inserisci il nome del prodotto:");

    if (carrello.Count == 0)
    {
        Console.WriteLine("Il carrello è vuoto. Nessun prodotto da rimuovere.\n");
        return;
    }

    foreach (var cibo in carrello)
    {
        Console.WriteLine($"{cibo.Key} - Quantità: {cibo.Value}");
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
                Console.WriteLine($"{prodotto} rimosso completamente dal carrello.\n");
            }
        }
        else
        {
            Console.WriteLine("Quantità non valida.");
        }
    }
    else
    {
        Console.WriteLine("Prodotto non trovato nel carrello.");
    }
}

void EffettuaPagamento(Dictionary<string, int> carrello)
{
    Console.WriteLine("Pagamento");
    if (carrello.Count == 0)
    {
        Console.WriteLine("Il carrello è vuoto. Niente da pagare.");
    }
    else
    {
        Console.WriteLine("Grazie per aver effettuato l'acquisto!");
        carrello.Clear();
    }
}
```