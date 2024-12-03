# Esercitazione 17: Supermercato completo

## Obiettivo:

- Implementare un programma che simuli il funzionamento di un supermercato.
- Il programma deve permettere ad un operatore di:
    - Gestire un catalogo di prodotti (Gestire prodotti del catalogo. Salvare e caricare il catalogo dei prodotti da un file JSON.)
- Il programma deve permettere a un cliente di riempire il proprio carrello della spesa
- Calcolare il totale del carrello e stampare uno scontrino

## Funzionalita':

Gestione del catalogo prodotti (operazioni CRUD):
- Id codice prodotto
- Nome prodotto
- Prezzo
- Quantità disponibile (in magazzino che viene decrementata quando un cliente acquista un prodotto)

Gestione del carrello e dello scontrino del cliente:
- Data di acquisto
- Lista dei prodotti acquistati
- Quantità per prodotto
- Totale spesa

Gestione dello store:
- Salvare il catalogo su file.
- Caricare il catalogo dal file.
- Salvare lo scontrino su file.
- Caricare lo scontrino dal file.
- Visualizzare il catalogo dei prodotti.
- Visualizzare gli scontrini.
- Implementare alcuni filtri (es. prodotti con prezzo minore di un certo valore, prodotti acquistati in una certa data, ecc.)

## Implementazioni future:

- Gestione operatori del supermercato (anagrafica, ruoli, ecc.)
- Gestione clienti (anagrafica, storico acquisti, ecc.)
- Gestione punti fedelta' (es. sconti, premi, ecc.)
- Gestione magazzino (funzionalita di rifornimento, gestione sottoscorta, ecc.)

## PROGRAMMA COMPLETO (da revisionare):

```csharp
using Newtonsoft.Json;
// Funzione per creare un prodotto
Dictionary<string, object> CreaProdotto(int id, string nome, double prezzo, int quantita)
{
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
    try
    {
        string json = JsonConvert.SerializeObject(catalogo, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Errore durante il salvataggio del catalogo: {ex.Message}");
    }
}

// Funzione per caricare un catalogo da file JSON
List<Dictionary<string, object>> CaricaCatalogo(string filePath)
{
    try
    {
        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json) ?? new List<Dictionary<string, object>>();
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("Il file non esiste. Creazione di un catalogo vuoto.");
        return new List<Dictionary<string, object>>();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Errore durante il caricamento del catalogo: {ex.Message}");
        return new List<Dictionary<string, object>>();
    }
}

// Funzione per visualizzare il catalogo
void VisualizzaCatalogo(List<Dictionary<string, object>> catalogo)
{
    if (catalogo.Count == 0)
    {
        Console.WriteLine("Il catalogo è vuoto.");
        return;
    }

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
double CalcolaTotale(List<Dictionary<string, object>> carrello)
{
    return carrello.Sum(p => (double)p["Prezzo"] * (int)p["Quantita"]);
}

// Funzione per stampare lo scontrino
void StampaScontrino(List<Dictionary<string, object>> carrello, double totale)
{
    Console.WriteLine($"Data: {DateTime.Now}");
    if (carrello.Count == 0)
    {
        Console.WriteLine("Il carrello è vuoto.");
    }
    else
    {
        foreach (var prodotto in carrello)
        {
            Console.WriteLine($"Nome: {prodotto["Nome"]}, Prezzo: {prodotto["Prezzo"]}€, Quantità: {prodotto["Quantita"]}");
        }
    }
    Console.WriteLine($"Totale: {totale}€");
}

// Funzione per salvare lo scontrino su file JSON
void SalvaScontrino(string filePath, List<Dictionary<string, object>> scontrino)
{
    try
    {
        string json = JsonConvert.SerializeObject(scontrino, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Errore durante il salvataggio dello scontrino: {ex.Message}");
    }
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
    ```