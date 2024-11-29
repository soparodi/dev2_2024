## GIOCO DEI DADI

## Versione 1

## Obiettivo:

- implementare un gioco di dadi umano vs computer
- il giocatore ed il computer lanciano un dado a 6 facce
- il punteggio più alto vince
- il gioco deve chiedere all'utente se vuole continuare a giocare
- il gioco in questa versione viene realizzato senza funzioni

```csharp
string risposta = ""; 

do
{
    // Funzione per generare i valori dei dadi
    int EstrazioneDadi()
    {
        Random random = new Random();
        return random.Next(1, 7);
    }

    // Estraggo i valori dei dadi per l'utente e per il computer
    int dadoUtente = EstrazioneDadi();
    int dadoComputer = EstrazioneDadi();

    // Funzione per stampare i risultati dei lanci
    void StampaFacce()
    {
        Console.WriteLine("Lancia il dado e premi Invio per vedere il risultato.");
        Console.ReadLine();

        Console.WriteLine("E' uscito: " + dadoUtente);
        Console.WriteLine("Ora lancia il computer e premi Invio per vedere il risultato.");
        Console.ReadLine();

        Console.WriteLine("E' uscito: " + dadoComputer);
    }

    // Chiamo la funzione per stampare i risultati
    StampaFacce();

    // Determino e stampo il risultato della partita
    if (dadoUtente > dadoComputer)
    {
        Console.WriteLine("Hai vinto!");
    }
    else if (dadoUtente < dadoComputer)
    {
        Console.WriteLine("Hai perso.");
    }
    else
    {
        Console.WriteLine("Pareggio.");
    }

    // Chiedo all'utente se vuole giocare di nuovo
    Console.WriteLine("Vuoi giocare di nuovo? (s/n)");
    risposta = Console.ReadLine();

    // Controllo input valido
    while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
    {
        Console.WriteLine("Risposta non valida. Vuoi giocare di nuovo? (s/n)");
        risposta = Console.ReadLine();
    }

} while (risposta == "s" || risposta == "S");
```


## Versione 3

## Obiettivo:

- implementare un sistema di punteggio
- il giocatore ed il computer partono da un punteggio di 100 punti
- al vincitore vengono assegnati 10 punti, più la differenza tra il lancio del dado del giocatore e del computer
- al perdente vengono sottratti 10 punti, più la differenza tra il lancio del dado del giocatore e del computer
- ad esempio, se il giocatore fa 6 ed il computer fa 3, il giocatore vince e guadagna 10+3 andando a 113 punti, mentre il computer perde 10+3 andando a 87 punti

```csharp

```


## Versione 4

## Obiettivo:

- implementare lo storico dei punteggi
- a fine partita viene stampato lo storico dei punteggi del giocatore e del computer
- lo storico contiene solo i punteggi della partita corrente

```csharp
string risposta = "";

// Inizializzo i punteggi di partenza
int punteggioGiocatore = 100;
int punteggioComputer = 100;

// Creo delle liste per lo storico dei punteggi di ogni partita
List<int> storicoGiocatore = new List<int>();
List<int> storicoComputer = new List<int>();

do
{
    // Funzione per generare i valori dei dadi
    int EstrazioneDadi()
    {
        Random random = new Random();
        return random.Next(1, 7);
    }

    // Estraggo i valori dei dadi per l'utente e per il computer
    int dadoUtente = EstrazioneDadi();
    int dadoComputer = EstrazioneDadi();

    // Funzione per stampare i risultati dei lanci
    void StampaFacce()
    {
        Console.WriteLine("Lancia il dado e premi Invio per vedere il risultato.");
        Console.ReadLine();

        Console.WriteLine("E' uscito per il giocatore: " + dadoUtente);
        Console.WriteLine("Ora lancia il computer e premi Invio per vedere il risultato.");
        Console.ReadLine();

        Console.WriteLine("E' uscito per il computer: " + dadoComputer);
    }

    // Chiamo la funzione per stampare i risultati
    StampaFacce();

    // Calcolo la differenza tra i risultati
    int differenza = Math.Abs(dadoUtente - dadoComputer);

    // Determino e stampo il risultato della partita, aggiornando i punteggi
    if (dadoUtente > dadoComputer)
    {
        punteggioGiocatore += 10 + differenza;
        punteggioComputer -= 10 + differenza;
        Console.WriteLine("Hai vinto questa partita!");
    }
    else if (dadoUtente < dadoComputer)
    {
        punteggioGiocatore -= 10 + differenza;
        punteggioComputer += 10 + differenza;
        Console.WriteLine("Hai perso questa partita.");
    }
    else
    {
        Console.WriteLine("Pareggio.");
    }

    // Aggiungo i punteggi attuali allo storico della partita corrente
    storicoGiocatore.Add(punteggioGiocatore);
    storicoComputer.Add(punteggioComputer);

    // Chiedo all'utente se vuole giocare di nuovo
    Console.WriteLine("Vuoi giocare di nuovo? (s/n)");
    risposta = Console.ReadLine();

    // Controllo input valido
    while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
    {
        Console.WriteLine("Risposta non valida. Vuoi giocare di nuovo? (s/n)");
        risposta = Console.ReadLine();
    }

} while (risposta == "s" || risposta == "S");

// Stampo lo storico dei punteggi al termine del gioco
Console.WriteLine("\nStorico dei punteggi della partita:");
for (int i = 0; i < storicoGiocatore.Count; i++)
{
    Console.WriteLine($"Round {i + 1}: Giocatore = {storicoGiocatore[i]}, Computer = {storicoComputer[i]}");
}
```