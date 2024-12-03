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


# Versione 1:

## Creazione della funzione CreaProdotto

## Obiettivo:

- Crea una funzione che restituisca un dizionario contenente le informazioni di un prodotto (ID, nome, prezzo e quantità).
- La funzione crea un dizionario con i dettagli di un prodotto, che include Id, Nome, Prezzo, e Quantita.
- Questo dizionario sarà utilizzato per rappresentare ciascun prodotto nel catalogo e nel carrello.


```csharp

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
```


# Versione 2

## Creazione della funzione SalvaCatalogo

## Obiettivo:

- Crea una funzione per serializzare il catalogo in formato JSON e salvarlo su un file.
- La funzione SalvaCatalogo serializza una lista di dizionari (catalogo) in formato JSON.
- Il JSON risultante viene scritto su un file specificato tramite filePath.
- Viene gestita un'eccezione per evitare crash nel caso di errori durante il salvataggio.


```csharp
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
```


# Versione 3

## Creazione della funzione CaricaCatalogo

## Obiettivo:

- Crea una funzione per caricare un catalogo da un file JSON e deserializzarlo.
- La funzione legge il contenuto del file JSON e lo deserializza in una lista di dizionari.
- Se il file non esiste o la deserializzazione fallisce, il programma gestisce l'errore e restituisce un catalogo vuoto.


```csharp
List<Dictionary<string, object>> CaricaCatalogo(string filePath)
{
    try
    {
        string json = File.ReadAllText(filePath);
        List<Dictionary<string, object>> catalogoDeserializzato = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

        if (catalogoDeserializzato == null)
        {
            return new List<Dictionary<string, object>>(); // Restituisce una lista vuota
        }
       
        return catalogoDeserializzato;
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("Il file non esiste. Creazione di un catalogo vuoto.");
        return new List<Dictionary<string, object>>(); // Restituisce una lista vuota
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Errore durante il caricamento del catalogo: {ex.Message}");
        return new List<Dictionary<string, object>>(); // Restituisce una lista vuota in caso di errore
    }
}
```


# Versione 4

## Creazione della funzione VisualizzaCatalogo

## Obiettivo:

- Crea una funzione che visualizzi i dettagli di tutti i prodotti nel catalogo.
- La funzione stampa ogni prodotto nel catalogo, mostrando ID, nome, prezzo e quantità.
- Se il catalogo è vuoto, il programma stampa un messaggio di avviso.


```csharp
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
```


# Versione 5

## Creazione della funzione AggiungiAlCarrello

## Obiettivo:

- Aggiungi un prodotto al carrello, aggiornando il catalogo e il carrello stesso.
- La funzione cerca il prodotto nel catalogo tramite l'ID.
- Se il prodotto è trovato e la quantità è sufficiente, lo aggiunge al carrello e riduce la quantità nel catalogo.


```csharp
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
```


# Versione 6

## Creazione della funzione CalcolaTotale

## Obiettivo:

- Calcolare il totale del carrello.
- La funzione somma il prezzo di ogni prodotto nel carrello, moltiplicato per la sua quantità, per calcolare il totale.


```csharp
double CalcolaTotale(List<Dictionary<string, object>> carrello)
{
    return carrello.Sum(p => (double)p["Prezzo"] * (int)p["Quantita"]);
}
```


# Versione 7

## Creazione della funzione StampaScontrino

## Obiettivo:

- Stampare i dettagli dello scontrino con i prodotti nel carrello e il totale.
- La funzione stampa la data attuale, i dettagli di ogni prodotto nel carrello e il totale.


```csharp
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
```


# Versione 8

## Creazione della funzione SalvaScontrino

## Obiettivo:

- Salvare lo scontrino in un file JSON.
- La funzione serializza il carrello in formato JSON e lo salva in un file specificato tramite filePath.


```csharp
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
```


# Versione 9

## Esecuzione del programma

## Obiettivo:

- Esegue il programma creando un catalogo, aggiungendo prodotti al carrello e salvando i dati.

```csharp
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


# PROGRAMMA COMPLETO (da revisionare):

```csharp
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
    try
    {
        // Serializza il catalogo in formato JSON
        string json = JsonConvert.SerializeObject(catalogo, Formatting.Indented);

        // Scrive il JSON nel file specificato dal percorso (filePath)
        File.WriteAllText(filePath, json);
    }
    catch (Exception ex)
    {
        // In caso di errore (ad esempio, se non si può scrivere il file), cattura l'eccezione e stampa un messaggio
        Console.WriteLine($"Errore durante il salvataggio del catalogo: {ex.Message}");
    }
}

// Funzione per caricare un catalogo da file JSON
List<Dictionary<string, object>> CaricaCatalogo(string filePath)
{
    try
    {
        // Legge il contenuto del file JSON
        string json = File.ReadAllText(filePath);

        // Deserializza il contenuto JSON nel formato appropriato (una lista di dizionari)
        List<Dictionary<string, object>> catalogoDeserializzato = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

        // Se la deserializzazione restituisce null, ritorna una lista vuota
        if (catalogoDeserializzato == null)
        {
            return new List<Dictionary<string, object>>(); // Restituisce una lista vuota
        }
        
        // Se la deserializzazione è andata a buon fine, restituisce il catalogo deserializzato
        return catalogoDeserializzato;
    }
    catch (FileNotFoundException)
    {
        // Se il file non viene trovato, cattura l'eccezione e crea un catalogo vuoto
        Console.WriteLine("Il file non esiste. Creazione di un catalogo vuoto.");
        return new List<Dictionary<string, object>>(); // Restituisce una lista vuota
    }
    catch (Exception ex)
    {
        // In caso di altri errori, cattura l'eccezione e stampa un messaggio di errore
        Console.WriteLine($"Errore durante il caricamento del catalogo: {ex.Message}");
        return new List<Dictionary<string, object>>(); // Restituisce una lista vuota in caso di errore
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

    // Scorre i prodotti nel catalogo e li visualizza
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
    // Calcola la somma totale moltiplicando prezzo per quantità per ogni prodotto nel carrello
    return carrello.Sum(p => (double)p["Prezzo"] * (int)p["Quantita"]);
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
    try
    {
        // Serializza il carrello (scontrino) in formato JSON
        string json = JsonConvert.SerializeObject(scontrino, Formatting.Indented);

        // Scrive il JSON nel file specificato
        File.WriteAllText(filePath, json);
    }
    catch (Exception ex)
    {
        // In caso di errore, cattura l'eccezione e stampa un messaggio
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