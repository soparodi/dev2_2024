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