# INDOVINA NUMERO

## Obiettivo

L'obiettivo di questa applicazione e di indovinare un **numero casuale** generato dal computer.

> Passaggi:

1. Il computer genera un numero casuale tra 1 e 100.
2. L'utente inserisce un numero.
3. Il computer confronta il numero inserito con quello generato.
4. Se il numero inserito è uguale a quello generato, l'utente ha indovinato.
5. Altrimenti, il computer fornisce un suggerimento (maggiore o minore) e l'utente può inserire un nuovo numero.
6. Il gioco termina quando l'utente indovina il numero o quando raggiunge il numero massimo di tentativi.

> **Esempio di codice:**

## Versione 1

```csharp
Random random = new Random(); // Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101); // Next e il metodo che genera un numero casuale tra 1 e 100

Console.WriteLine("Indovina il numero (tra 1 e 100): ");

int numeroInserito;

numeroInserito = Convert.ToInt32(Console.ReadLine()); // converto il valore inserito dall'utente in un intero perche 

if (numeroInserito == numeroDaIndovinare)
{
   Console.WriteLine("Complimenti! Hai indovinato il numero.");
}
else
{
   Console.WriteLine("Mi dispiace! Non hai indovinato il numero.");
    Console.WriteLine($"Il numero da indovinare era: {numeroDaIndovinare}");
}
```
### Comandi versionamento

```bash
git add --all
git commit -m "Indovina Numero: Versione 1"
git push -u origin main
```
## Versione 2

**Obiettivo:**  
Modifica il programma precedente per fornire all'utente suggerimenti dopo ogni tentativo, indicando se il numero da indovinare è maggiore o minore di quello inserito.

**Istruzioni:**

* Usa un ciclo while per permettere all'utente di continuare a tentare finché non indovina.  
* Dopo ogni tentativo errato, indica se il numero da indovinare è maggiore o minore di quello inserito.  
* Quando l'utente indovina, esci dal ciclo e stampa un messaggio di congratulazioni.

> **Esempio di codice:**

## Versione 2

```csharp
Random random = new Random(); // Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101); // Next e il metodo che genera un numero casuale tra 1 e 100

Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 100): ");

int numeroInserito;

numeroInserito = 0; // Inizializzo a 0 per entrare nel ciclo while

while (numeroInserito != numeroDaIndovinare)
{
    numeroInserito = Convert.ToInt32(Console.ReadLine());
    
    if (numeroInserito < numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' maggiore");
    }
    else
    {
        Console.WriteLine("Il numero da indovinare e' minore");
    }

    Console.WriteLine("Riprova: ");
    
}

Console.WriteLine("Hai indovinato! Il numero da indovinare era: " + numeroDaIndovinare);
```

### Comandi versionamento

```bash
git add --all
git commit -m "Indovina Numero: Versione 2"
git push -u origin main
```

## Versione 3

**Obiettivo:**  
Imposta un numero massimo di tentativi (ad esempio, 5). Se l'utente non indovina entro questi tentativi, il gioco termina.

**Istruzioni:**

* Imposta una variabile booleana per tenere traccia se l'utente ha indovinato.
* Mantieni un contatore di tentativi all'interno del ciclo while.  
* Dopo ogni tentativo, decrementa il numero di tentativi rimasti e informane l'utente.  
* Se i tentativi esauriscono senza che l'utente abbia indovinato, stampa un messaggio di sconfitta e rivela il numero.

**Esempio di codice:**

```csharp
Random random = new Random(); // Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101); // Next e il metodo che genera un numero casuale tra 1 e 100
int numeroInserito;
int tentativiMassimi = 5;  
int tentativiEffettuati = 0;  
bool haIndovinato = false;
int numeroUtente = 0;

Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 100). Hai 5 tentativi.");

while (tentativiEffettuati < tentativiMassimi && !haIndovinato)  
{  
    Console.Write("Tentativo {0}: ", tentativiEffettuati + 1);  
    
    // numeroUtente = int.Parse(Console.ReadLine());  
    numeroUtente = int.Parse(Console.ReadLine());
    
    tentativiEffettuati++;

    if (numeroUtente < numeroDaIndovinare)  
    {  
        Console.WriteLine("Il numero da indovinare è maggiore.");  
    }  
    else if (numeroUtente > numeroDaIndovinare)  
    {  
        Console.WriteLine("Il numero da indovinare è minore.");  
    }  
    else  
    {  
        Console.WriteLine("Complimenti! Hai indovinato il numero.");  
        haIndovinato = true;  
    }

    if (!haIndovinato && tentativiEffettuati == tentativiMassimi)  
    {  
        Console.WriteLine("Hai esaurito i tentativi. Il numero era " + numeroDaIndovinare + ".");  
    }  
}
```

### Comandi versionamento

```bash
git add --all
git commit -m "Indovina Numero: Versione 3"
git push -u origin main
```

## Versione 4

**Obiettivo:**  
Assegna un punteggio all'utente in base al numero di tentativi utilizzati. Più tentativi impiega, minore sarà il punteggio.

**Istruzioni:**

* Inizia con un punteggio massimo (ad esempio, 100 punti).  
* Ad ogni tentativo fallito, sottrai un certo numero di punti (ad esempio, 2 punti).  
* Alla fine del gioco, mostra il punteggio all'utente.

**Esempio di codice:**

```csharp
Random random = new Random();
int numeroDaIndovinare = random.Next(1, 101);  
int punteggio = 100;  
bool haIndovinato = false;

Console.WriteLine("Indovina il numero (tra 1 e 100). Punteggio massimo: 100 punti.");

while (!haIndovinato && punteggio > 0)  
{  
    Console.Write("Tentativo: ");  
    int numeroUtente = int.Parse(Console.ReadLine());  
    punteggio -= 2;

    if (numeroUtente < numeroDaIndovinare)  
    {  
        Console.WriteLine("Il numero da indovinare è maggiore.");  
    }  
    else if (numeroUtente > numeroDaIndovinare)  
    {  
        Console.WriteLine("Il numero da indovinare è minore.");  
    }  
    else  
    {  
        Console.WriteLine("Hai indovinato! Punteggio: " + punteggio);  
        haIndovinato = true;  
    }

    if (!haIndovinato && punteggio == 0)  
    {  
        Console.WriteLine("Hai esaurito i tentativi. Il numero era " + numeroDaIndovinare + ".");  
    }  
}
```

oppure

```csharp
Random random = new Random(); // Random e la classe che genera numeri casuali
int numeroDaIndovinare = random.Next(1, 101); // Next e il metodo che genera un numero casuale tra 1 e 100
int punteggio = 20;
bool haIndovinato = false;
// int numeroInserito = 0;

Console.Clear();

Console.WriteLine("Indovina il numero (tra 1 e 100). Hai 5 tentativi: ");

while (!haIndovinato)

{
    Console.WriteLine("Punteggio {0}: ", punteggio);

    int numeroInserito = Convert.ToInt32(Console.ReadLine());

    punteggio--;

    if (numeroInserito < numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' maggiore");
    }
    else if (numeroInserito > numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' minore");

        Console.WriteLine("Riprova: ");
    }
    else
    {
        Console.WriteLine("Hai indovinato");
        haIndovinato = true;
    }

    if (punteggio == 0 && !haIndovinato)
    {
        Console.WriteLine($"Hai finito i punti. Il numero da indovinare era: {numeroDaIndovinare}");
    }
}
```

# Versione 5

**Obiettivo:**

* **Livelli di Difficoltà:** Permetti all'utente di scegliere tra diversi livelli di difficoltà che modificano il munero di punti sottratti o l'intervallo dei numeri o il numero di tentativi disponibili.  

**Istruzioni:**

1. **Livelli di Difficoltà:**  
   * **Facile:** Numeri da 1 a 50, 10 tentativi.  
   * **Medio:** Numeri da 1 a 100, 7 tentativi.  
   * **Difficile:** Numeri da 1 a 200, 5 tentativi. 

```csharp
Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;

Console.WriteLine("Scegli il livello di difficolta':");
Console.WriteLine("1. Facile (1-50, 10 tentativi)");
Console.WriteLine("2. Medio (1-100, 7 tentativi)");
Console.WriteLine("3. Difficile (1-200, 5 tentativi)");

int scelta = int.Parse(Console.ReadLine());

switch (scelta)
{
    case 1:
        numeroDaIndovinare = random.Next(1, 51);
        punteggio = 100;
        tentativi = 10;
        break;
    case 2:
        numeroDaIndovinare = random.Next(1, 101);
        punteggio = 100;
        tentativi = 7;
        break;
    case 3:
        numeroDaIndovinare = random.Next(1, 201);
        punteggio = 100;
        tentativi = 5;
        break;
    default:
        Console.WriteLine("Scelta non valida.");
        break;
}

Console.WriteLine("Indovina il numero. Punteggio massimo: 100 punti.");

while (!haIndovinato && tentativi > 0)
{
    Console.Write("Tentativo: ");
    numeroUtente = int.Parse(Console.ReadLine());
    tentativi--;

    if (numeroUtente < numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' maggiore.");
    }
    else if (numeroUtente > numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' minore.");
    }
    else
    {
        Console.WriteLine("Hai indovinato! Punteggio: " + punteggio);
        haIndovinato = true;
    }

    if (!haIndovinato && tentativi == 0)
    {
        Console.WriteLine("Hai esaurito i tentativi. Il numero era " + numeroDaIndovinare + ".");
    }
}
```

### Comandi versionamento

```bash
git add --all
git commit -m "Indovina Numero: Versione 5"
git push -u origin main
```


## Versione 6

**Obiettivo:**

**Storico dei Tentativi:** Mostra all'utente tutti i numeri inseriti precedentemente. 

**Istruzioni:**

* Utilizza una lista per memorizzare i tentativi dell'utente.
I tentativi sono memorizzati fino a quando l'utente indovina il numero o esaurisce i tentativi ma vengono persi quando viene eseguito il codice successivo.

```csharp
Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;

List<int> tentativiUtente = new List<int>(); // creo una lista per memorizzare i tentativi

Console.WriteLine("Scegli il livello di difficolta':");
Console.WriteLine("1. Facile (1-50, 10 tentativi)");
Console.WriteLine("2. Medio (1-100, 7 tentativi)");
Console.WriteLine("3. Difficile (1-200, 5 tentativi)");

int scelta = int.Parse(Console.ReadLine());

switch (scelta)
{
    case 1:
        numeroDaIndovinare = random.Next(1, 51);
        punteggio = 100;
        tentativi = 10;
        break;
    case 2:
        numeroDaIndovinare = random.Next(1, 101);
        punteggio = 100;
        tentativi = 7;
        break;
    case 3:
        numeroDaIndovinare = random.Next(1, 201);
        punteggio = 100;
        tentativi = 5;
        break;
    default:
        Console.WriteLine("Scelta non valida.");
        break;
}

Console.WriteLine("Indovina il numero. Punteggio massimo: 100 punti.");

while (!haIndovinato && tentativi > 0)
{
    Console.Write("Tentativo: ");
    numeroUtente = int.Parse(Console.ReadLine());
    tentativiUtente.Add(numeroUtente); // aggiungo il tentativo alla lista
    tentativi--;

    if (numeroUtente < numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' maggiore.");
    }
    else if (numeroUtente > numeroDaIndovinare)
    {
        Console.WriteLine("Il numero da indovinare e' minore.");
    }
    else
    {
        Console.WriteLine($"Hai indovinato! Punteggio: {punteggio}");
        haIndovinato = true;
    }

    if (!haIndovinato && tentativi == 0)
    {
        Console.WriteLine($"Hai esaurito i tentativi. Il numero era {numeroDaIndovinare}.");
    }
}

Console.WriteLine("Tentativi effettuati: ");

// creo un foreach per stampare i tentativi effettuati usando la lista tentativiUtente
foreach (int tentativo in tentativiUtente)
{
    Console.Write($"{tentativo} "); // stampo i tentativi effettuati
}
```

- creo una lista dei num tentativi (nome var "tentativiUtente")
- il programma cambia quando nel while inseriamo i tentativi
- cicliamo in "tentativiUtente" con una nuova var "tentativo" - 'foreach (int tentativo in tentativiUtente)'
- ogni tentativo deve ciclare e poi per ognuno deve andare ad esporre un tentativo (metodo Add)
- aggiungo alla lista tentativi e incremento il numero tentativi
- faccio inserire il numero all'utente e lo converto in intero
- creo un foreach per stampare i tentativi effettuati usando la lista "tentativiUtente"


## Versione 7

**Obiettivo:**

**Validazione degli input**: Aggiungi controlli per assicurarti che l'utente inserisca un numero valido.

**Istruzioni:**

- Utilizza il metodo `int.TryParse` per convertire l'input dell'utente in un numero intero.

Il TryParse funziona cosi:

```csharp
/*
int numeroUtente;

bool successo = int.TryParse(Console.ReadLine(), out numeroUtente);

if (successo)
{
    // il numeroUtente e' stato convertito correttamente
    // posso usare il valore di numeroUtente
}
else
{
    // l'utente ha inserito un valore non valido
    Console.WriteLine("Inserisci un numero valido.");
    continue; // salto il resto del ciclo e vado al prossimo tentativo
}
*/
Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;

List<int> tentativiUtente = new List<int>();

Console.WriteLine("Scegli il livello di difficolta':");
Console.WriteLine("1. Facile (1-50, 10 tentativi)");
Console.WriteLine("2. Medio (1-100, 7 tentativi)");
Console.WriteLine("3. Difficile (1-200, 5 tentativi)");

// int scelta = int.Parse(Console.ReadLine());
int scelta = 0; // Inizializzo la variabile scelta a 0
bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta); // TryParse restituisce true se la conversione è riuscita, altrimenti false

// se la conversione non è riuscita oppure la scelta non è compresa tra 1 e 3
if (!successoLivelloDifficolta || scelta < 1 || scelta > 3)
{
    Console.WriteLine("Scelta non valida."); // Stampo un messaggio di errore
}
else
{
    switch (scelta)
    {
        case 1:
            numeroDaIndovinare = random.Next(1, 51);
            punteggio = 100;
            tentativi = 10;
            break;
        case 2:
            numeroDaIndovinare = random.Next(1, 101);
            punteggio = 100;
            tentativi = 7;
            break;
        case 3:
            numeroDaIndovinare = random.Next(1, 201);
            punteggio = 100;
            tentativi = 5;
            break;
        default:
            Console.WriteLine("Scelta non valida.");
            break;
    }

    Console.WriteLine("Indovina il numero. Punteggio massimo: 100 punti.");

    while (!haIndovinato && tentativi > 0)
    {
        Console.Write("Tentativo: ");
        bool successo = int.TryParse(Console.ReadLine(), out numeroUtente); // TryParse restituisce true se la conversione è riuscita, altrimenti false

        if (!successo)
        {
            Console.WriteLine("Inserisci un numero valido."); // Se l'utente non ha inserito un numero valido, si salta il tentativo
            continue; // Salta il resto del ciclo e va al prossimo tentativo
        }

        tentativiUtente.Add(numeroUtente);
        tentativi--;

        if (numeroUtente < numeroDaIndovinare)
        {
            Console.WriteLine("Il numero da indovinare e' maggiore.");
        }
        else if (numeroUtente > numeroDaIndovinare)
        {
            Console.WriteLine("Il numero da indovinare e' minore.");
        }
        else
        {
            Console.WriteLine($"Hai indovinato! Punteggio: {punteggio}");
            haIndovinato = true;
        }

        if (!haIndovinato && tentativi == 0)
        {
            Console.WriteLine($"Hai esaurito i tentativi. Il numero era {numeroDaIndovinare}.");
        }
    }

    Console.WriteLine("Tentativi effettuati: ");

    foreach (int tentativo in tentativiUtente)
    {
        Console.Write($"{tentativo} ");
    }
}
```

### Comandi versionamento

```bash
git add --all
git commit -m "Indovina Numero: Versione 7"
git push -u origin main
```

## Versione 8

**Obiettivo:**

**Ripetizione del Livello:** Chiedi all'utente di inserire il livello di difficoltà finché non sceglie un livello valido.

Se vogliamo che chieda di nuovo il livello di difficoltà quando la scelta non è valida dobbiamo mettere tutto il codice precedente in un ciclo do-while e fare in modo che il ciclo si ripeta finché la scelta non è valida


- STOP

```csharp

```

- ok 1
- ok 2
- ok 3

_prova_

github markdown preview
markdown preview github styling