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