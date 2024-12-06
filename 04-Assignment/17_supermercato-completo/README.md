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

- Creo una funzione che restituisca un dizionario contenente le informazioni di un prodotto (ID, nome, prezzo e quantità).
- La funzione crea un dizionario con i dettagli di un prodotto, che include Id, Nome, Prezzo, e Quantita.
- Questo dizionario sarà utilizzato per rappresentare ciascun prodotto nel catalogo e nel carrello.


```csharp
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
```


# Versione 2

## Creazione della funzione SalvaCatalogo

## Obiettivo:

- Creo una funzione per serializzare il catalogo in formato JSON e salvarlo su un file.
- La funzione SalvaCatalogo serializza una lista di dizionari (catalogo) in formato JSON.
- Il JSON risultante viene scritto su un file specificato tramite filePath.

```csharp
// Funzione per salvare un catalogo in formato JSON
void SalvaCatalogo(string filePath, List<Dictionary<string, object>> catalogo)
{
    // Serializza il catalogo in formato JSON
    string json = JsonConvert.SerializeObject(catalogo, Formatting.Indented);

    // Scrive il JSON nel file specificato dal percorso (filePath)
    File.WriteAllText(filePath, json);
}
```


# Versione 3

## Creazione della funzione CaricaCatalogo

## Obiettivo:

- Creo una funzione per caricare un catalogo da un file JSON e deserializzarlo.
- La funzione legge il contenuto del file JSON e lo deserializza in una lista di dizionari.


```csharp
// Funzione per caricare un catalogo da file JSON
List<Dictionary<string, object>> CaricaCatalogo(string filePath)
{
    // Legge il contenuto del file JSON
    string json = File.ReadAllText(filePath);

    // Deserializza il contenuto JSON in una lista di dizionari
    List<Dictionary<string, object>> catalogoDeserializzato = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

    // Restituisce il catalogo deserializzato
    return catalogoDeserializzato;
}
```


# Versione 4

## Creazione della funzione VisualizzaCatalogo

## Obiettivo:

- Creo una funzione che visualizzi i dettagli di tutti i prodotti nel catalogo.
- La funzione stampa ogni prodotto nel catalogo, mostrando ID, nome, prezzo e quantità.


```csharp
// Funzione per visualizzare il catalogo
void VisualizzaCatalogo(List<Dictionary<string, object>> catalogo)
{
    // Scorre i prodotti nel catalogo e li visualizza
    foreach (var prodotto in catalogo)
    {
        Console.WriteLine($"Id: {prodotto["Id"]}, Nome: {prodotto["Nome"]}, Prezzo: {prodotto["Prezzo"]}€, Quantità: {prodotto["Quantita"]}");
    }
}
```


# Versione 5

## Creazione della funzione TrovaProdotto

## Obiettivo:

- Cerco un prodotto nel catalogo.
- Se la funzione non trova alcun prodotto, restituisce un dizionario vuoto.

```csharp
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
```

# Versione 6

## Creazione della funzione AggiungiAlCarrello

## Obiettivo:

- Aggiungo un prodotto al carrello, aggiornando il catalogo e il carrello stesso.
- La funzione cerca il prodotto nel catalogo tramite l'ID.
- Se il prodotto è trovato e la quantità è sufficiente, lo aggiunge al carrello e riduce la quantità nel catalogo.


```csharp
// Funzione per aggiungere un prodotto al carrello
List<Dictionary<string, object>> AggiungiAlCarrello(
    List<Dictionary<string, object>> catalogo,
    int id,
    int quantita,
    List<Dictionary<string, object>> carrello)
{
    // Trova il prodotto nel catalogo
    var prodotto = TrovaProdotto(catalogo, id);

    // Verifica se il prodotto esiste e se la quantità richiesta è disponibile
    if (prodotto.Count > 0 && (int)prodotto["Quantita"] >= quantita)
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


# Versione 7

## Creazione della funzione CalcolaTotale

## Obiettivo:

- Calcolo il totale del carrello.
- La funzione somma il prezzo di ogni prodotto nel carrello, moltiplicato per la sua quantità, per calcolare il totale.


```csharp
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
```


# Versione 8

## Creazione della funzione StampaScontrino

## Obiettivo:

- Stampo i dettagli dello scontrino con i prodotti nel carrello e il totale.
- La funzione stampa la data attuale, i dettagli di ogni prodotto nel carrello e il totale.


```csharp
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
```


# Versione 9

## Creazione della funzione SalvaScontrino

## Obiettivo:

- Salvo lo scontrino in un file JSON.
- La funzione serializza il carrello in formato JSON e lo salva in un file specificato tramite filePath.


```csharp
// Funzione per salvare lo scontrino su file JSON
void SalvaScontrino(string filePath, List<Dictionary<string, object>> scontrino)
{
    // Serializza il carrello (scontrino) in formato JSON
    string json = JsonConvert.SerializeObject(scontrino, Formatting.Indented);

    // Scrive il JSON nel file specificato
    File.WriteAllText(filePath, json);
}
```


# Versione 10

## Unire insieme le funzioni create per far funzionare il programma

## Obiettivo:

- Creo i due dizionari "catalogo" e "carrello".
- Aggiungo i prodotti creati al catalogo.
- Aggiungo i prodotti al carrello.
- Calcolo il totale e stampo lo scontrino.
- Salvo il catalogo e lo scontrino.


```csharp
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


# PROGRAMMA COMPLETO:

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

    // Deserializza il contenuto JSON in una lista di dizionari
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
    // Trova il prodotto nel catalogo
    var prodotto = TrovaProdotto(catalogo, id);

    // Verifica se il prodotto esiste e se la quantità richiesta è disponibile
    if (prodotto.Count > 0 && (int)prodotto["Quantita"] >= quantita)
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
```


## PROGRAMMA REVISIONATO:

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
    string json = JsonConvert.SerializeObject(catalogo, Formatting.Indented);
    File.WriteAllText(filePath, json);
}

// Funzione per caricare un catalogo da file JSON
List<Dictionary<string, object>> CaricaCatalogo(string filePath)
{
    string json = File.ReadAllText(filePath);
    return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json) ?? new List<Dictionary<string, object>>();
}

// Funzione per visualizzare il catalogo
void VisualizzaCatalogo(List<Dictionary<string, object>> catalogo)
{
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
    var prodotto = TrovaProdotto(catalogo, id);

    if (prodotto.Count > 0 && (int)prodotto["Quantita"] >= quantita)
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
    double totale = 0;

    foreach (var prodotto in carrello)
    {
        totale += (double)prodotto["Prezzo"] * (int)prodotto["Quantita"];
    }

    return totale;
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
    string json = JsonConvert.SerializeObject(scontrino, Formatting.Indented);
    File.WriteAllText(filePath, json);
}

// Catalogo e carrello
var catalogo = new List<Dictionary<string, object>>();
var carrello = new List<Dictionary<string, object>>();

// Verifica se il file catalogo.json esiste già
if (File.Exists("catalogo.json"))
{
    // Carica il catalogo dal file
    catalogo = CaricaCatalogo("catalogo.json");
    Console.WriteLine("Catalogo caricato dal file esistente:");
}
else
{
    // Crea un nuovo catalogo
    catalogo.Add(CreaProdotto(1, "Mela", 0.5, 100));
    catalogo.Add(CreaProdotto(2, "Pane", 1.0, 50));
    Console.WriteLine("Nuovo catalogo creato.");
    SalvaCatalogo("catalogo.json", catalogo);
}

// Visualizza il catalogo
VisualizzaCatalogo(catalogo);

// Gestione dell'input dell'utente per aggiungere prodotti al carrello
while (true)
{
    Console.WriteLine("Vuoi aggiungere un prodotto al carrello? (sì/no)");
    string risposta = Console.ReadLine()?.ToLower();

    if (risposta == "no") break;

    Console.Write("Inserisci l'Id del prodotto: ");
    int id = int.Parse(Console.ReadLine() ?? "0");

    Console.Write("Inserisci la quantità desiderata: ");
    int quantita = int.Parse(Console.ReadLine() ?? "0");

    carrello = AggiungiAlCarrello(catalogo, id, quantita, carrello);
}

// Calcola il totale e stampa lo scontrino
var totale = CalcolaTotale(carrello);
StampaScontrino(carrello, totale);

// Salva lo stato aggiornato del catalogo e il carrello
SalvaCatalogo("catalogo.json", catalogo);
SalvaScontrino("scontrino.json", carrello);
```

--