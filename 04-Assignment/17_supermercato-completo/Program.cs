// Funzione per creare un prodotto
Dictionary<string, object> CreaProdotto(int id, string nome, decimal prezzo, int quantita)
{
    return new Dictionary<string, object>
    {
        { "Id", id },
        { "Nome", nome },
        { "Prezzo", prezzo },
        { "Quantita", quantita }
    };
}

// Funzione per salvare il catalogo su file JSON
void SalvaCatalogo(string filePath, List<Dictionary<string, object>> catalogo)
{
    var json = JsonSerializer.Serialize(catalogo, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(filePath, json);
}

// Funzione per caricare il catalogo da file JSON
List<Dictionary<string, object>> CaricaCatalogo(string filePath)
{
    if (!File.Exists(filePath))
    {
        Console.WriteLine("Il file non esiste. Creazione di un catalogo vuoto.");
        return new List<Dictionary<string, object>>();
    }

    var json = File.ReadAllText(filePath);
    try
    {
        return JsonSerializer.Deserialize<List<Dictionary<string, object>>>(json) ?? new List<Dictionary<string, object>>();
    }
    catch
    {
        Console.WriteLine("Errore nella lettura del file JSON. Creazione di un catalogo vuoto.");
        return new List<Dictionary<string, object>>();
    }
}

// Funzione per stampare il catalogo
void VisualizzaCatalogo(List<Dictionary<string, object>> catalogo)
{
    foreach (var prodotto in catalogo)
    {
        Console.WriteLine($"Id: {prodotto["Id"]}, Nome: {prodotto["Nome"]}, Prezzo: {prodotto["Prezzo"]}€, Quantità: {prodotto["Quantita"]}");
    }
}

// Funzione per aggiungere un prodotto al carrello
List<Dictionary<string, object>> AggiungiAlCarrello(
    List<Dictionary<string, object>> catalogo,
    int id,
    int quantita,
    List<Dictionary<string, object>> carrello)
{
    var prodotto = catalogo.FirstOrDefault(p => (int)p["Id"] == id);
    if (prodotto != null && (int)prodotto["Quantita"] >= quantita)
    {
        prodotto["Quantita"] = (int)prodotto["Quantita"] - quantita;
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
        Console.WriteLine("Quantità insufficiente o prodotto non trovato.");
    }
    return carrello;
}

// Funzione per calcolare il totale del carrello
decimal CalcolaTotale(List<Dictionary<string, object>> carrello)
{
    return carrello.Sum(p => (decimal)p["Prezzo"] * (int)p["Quantita"]);
}

// Funzione per stampare lo scontrino
void StampaScontrino(List<Dictionary<string, object>> carrello, decimal totale)
{
    Console.WriteLine($"Data: {DateTime.Now}");
    foreach (var prodotto in carrello)
    {
        Console.WriteLine($"Nome: {prodotto["Nome"]}, Prezzo: {prodotto["Prezzo"]}€, Quantità: {prodotto["Quantita"]}");
    }
    Console.WriteLine($"Totale: {totale}€");
}

// Funzione per salvare lo scontrino su file JSON
void SalvaScontrino(string filePath, List<Dictionary<string, object>> scontrino)
{
    var json = JsonSerializer.Serialize(scontrino, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(filePath, json);
}

// Esempio d'uso delle funzioni
var catalogo = new List<Dictionary<string, object>>();
var carrello = new List<Dictionary<string, object>>();

// Aggiunta prodotti al catalogo
catalogo.Add(CreaProdotto(1, "Mela", 0.5m, 100));
catalogo.Add(CreaProdotto(2, "Pane", 1.0m, 50));

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