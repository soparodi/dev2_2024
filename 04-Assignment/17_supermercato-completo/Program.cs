using Newtonsoft.Json;

// Funzione per creare un prodotto
Dictionary<string, object> CreaProdotto(int id, string nome, double prezzo, int quantita)
{
    // Restituisce un dizionario con le informazioni del prodotto
    return new Dictionary<string, object>
    {
        { "Id", id },
        { "Nome", nome },
        { "Prezzo", prezzo },
        { "Quantita", quantita }
    };
}

// Funzione per salvare un catalogo in formato JSON
void SalvaCatalogo(string filePath, List<Dictionary<string, object>> catalogo)
{
    // Serializza il catalogo in formato JSON
    string json = JsonConvert.SerializeObject(catalogo, Formatting.Indented);

    // Scrive il JSON nel file specificato dal percorso (filePath)
    File.WriteAllText(filePath, json);
}

// Funzione per caricare un catalogo da file JSON
List<Dictionary<string, object>> CaricaCatalogo(string filePath)
{
    // Legge il contenuto del file JSON
    string json = File.ReadAllText(filePath);

    // Deserializza il contenuto JSON nel formato appropriato (una lista di dizionari)
    List<Dictionary<string, object>> catalogoDeserializzato = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

    // Restituisce il catalogo deserializzato
    return catalogoDeserializzato;
}

// Funzione per visualizzare il catalogo
void VisualizzaCatalogo(List<Dictionary<string, object>> catalogo)
{
    // Scorre i prodotti nel catalogo e li visualizza
    foreach (var prodotto in catalogo)
    {
        Console.WriteLine($"Id: {prodotto["Id"]}, Nome: {prodotto["Nome"]}, Prezzo: {prodotto["Prezzo"]}€, Quantità: {prodotto["Quantita"]}");
    }
}

// Funzione per trovare un prodotto nel catalogo
Dictionary<string, object> TrovaProdotto(List<Dictionary<string, object>> catalogo, int id)
{
    foreach (var prodotto in catalogo)
    {
        if ((int)prodotto["Id"] == id)
        {
            return prodotto; // Restituisce il prodotto trovato
        }
    }
    return new Dictionary<string, object>(); // Restituisce un dizionario vuoto se non trovato
}

// Funzione per aggiungere un prodotto al carrello
List<Dictionary<string, object>> AggiungiAlCarrello(
    List<Dictionary<string, object>> catalogo,
    int id,
    int quantita,
    List<Dictionary<string, object>> carrello)
{
    // Cerca il prodotto nel catalogo in base all'ID
    var prodotto = catalogo.FirstOrDefault(p => (int)p["Id"] == id);

    // Verifica se il prodotto esiste e se la quantità richiesta è disponibile
    if (prodotto != null && (int)prodotto["Quantita"] >= quantita)
    {
        // Riduce la quantità disponibile nel catalogo
        prodotto["Quantita"] = (int)prodotto["Quantita"] - quantita;

        // Aggiunge il prodotto al carrello
        carrello.Add(new Dictionary<string, object>
        {
            { "Id", prodotto["Id"] },
            { "Nome", prodotto["Nome"] },
            { "Prezzo", prodotto["Prezzo"] },
            { "Quantita", quantita }
        });
    }
    else
    {
        // Se non ci sono sufficienti scorte o il prodotto non è trovato, stampa un messaggio di errore
        Console.WriteLine("Quantità insufficiente o prodotto non trovato.");
    }
    return carrello;
}

// Funzione per calcolare il totale del carrello
double CalcolaTotale(List<Dictionary<string, object>> carrello)
{
    double totale = 0;

    // Scorre ogni prodotto nel carrello
    foreach (var prodotto in carrello)
    {
        // Calcola il costo totale per il prodotto e lo aggiunge al totale generale
        totale += (double)prodotto["Prezzo"] * (int)prodotto["Quantita"];
    }

    return totale;
}

// Funzione per stampare lo scontrino
void StampaScontrino(List<Dictionary<string, object>> carrello, double totale)
{
    // Stampa la data e ora attuale
    Console.WriteLine($"Data: {DateTime.Now}");

    if (carrello.Count == 0)
    {
        Console.WriteLine("Il carrello è vuoto.");
    }
    else
    {
        // Stampa i dettagli di ogni prodotto nel carrello
        foreach (var prodotto in carrello)
        {
            Console.WriteLine($"Nome: {prodotto["Nome"]}, Prezzo: {prodotto["Prezzo"]}€, Quantità: {prodotto["Quantita"]}");
        }
    }
    // Stampa il totale
    Console.WriteLine($"Totale: {totale}€");
}

// Funzione per salvare lo scontrino su file JSON
void SalvaScontrino(string filePath, List<Dictionary<string, object>> scontrino)
{
    // Serializza il carrello (scontrino) in formato JSON
    string json = JsonConvert.SerializeObject(scontrino, Formatting.Indented);

    // Scrive il JSON nel file specificato
    File.WriteAllText(filePath, json);
}

// Catalogo e carrello
var catalogo = new List<Dictionary<string, object>>();
var carrello = new List<Dictionary<string, object>>();

// Aggiunta prodotti al catalogo
catalogo.Add(CreaProdotto(1, "Mela", 0.5, 100));
catalogo.Add(CreaProdotto(2, "Pane", 1.0, 50));

// Visualizza catalogo
VisualizzaCatalogo(catalogo);

// Aggiungi prodotti al carrello
carrello = AggiungiAlCarrello(catalogo, 1, 3, carrello);
carrello = AggiungiAlCarrello(catalogo, 2, 2, carrello);

// Calcola il totale e stampa lo scontrino
var totale = CalcolaTotale(carrello);
StampaScontrino(carrello, totale);

// Salva il catalogo e lo scontrino su file
SalvaCatalogo("catalogo.json", catalogo);
SalvaScontrino("scontrino.json", carrello);