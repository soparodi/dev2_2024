string risposta = "";

// Inizializzo i punteggi di partenza
int punteggioGiocatore = 100;
int punteggioComputer = 100;

// Creo delle liste per lo storico dei punteggi di ogni partita
List<int> storicoGiocatore = new List<int>();
List<int> storicoComputer = new List<int>();

do
{
    Console.Clear();
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
        Console.WriteLine("Lancia il dado: (premi invio) ");
        Console.ReadLine();
        Thread.Sleep(1000);

        Console.WriteLine($"E' uscito: {dadoUtente}\n");
        Thread.Sleep(1000);

        Console.WriteLine("Ora lancia il computer: (premi invio) ");
        Console.ReadLine();
        Thread.Sleep(1000);

        Console.WriteLine($"E' uscito: {dadoComputer}\n");
        Thread.Sleep(1000);
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
        Console.WriteLine("Hai vinto!");
    }
    else if (dadoUtente < dadoComputer)
    {
        punteggioGiocatore -= 10 + differenza;
        punteggioComputer += 10 + differenza;
        Console.WriteLine("Hai perso.");
    }
    else
    {
        Console.WriteLine("Pareggio.");
    }

    Thread.Sleep(1500);
    Console.Clear();

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

Console.Clear();

// Stampo lo storico dei punteggi al termine del gioco
Console.WriteLine("Storico dei punteggi della partita: ");
for (int i = 0; i < storicoGiocatore.Count; i++)
{
    Console.WriteLine($"Round {i + 1}: Giocatore = {storicoGiocatore[i]}, Computer = {storicoComputer[i]}");
}