Random random = new Random(); // Usiamo un'unica istanza di Random

int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
string nomeUtente = "";

Dictionary<string, List<int>> tentativiUtenti = new Dictionary<string, List<int>>();

string risposta = "s";

do
{
    int scelta = ScegliDifficolta();

    switch (scelta)
    {
        case 1:
            numeroDaIndovinare = GeneraNumeroCasuale(1, 51);
            punteggio = 100;
            tentativi = 10;
            break;
        case 2:
            numeroDaIndovinare = GeneraNumeroCasuale(1, 101);
            punteggio = 200;
            tentativi = 7;
            break;
        case 3:
            numeroDaIndovinare = GeneraNumeroCasuale(1, 201);
            punteggio = 300;
            tentativi = 5;
            break;
        default:
            Console.WriteLine("Scelta non valida.");
            break;
    }

    nomeUtente = ChiediNomeUtente();

    IndovinaNumero(numeroDaIndovinare, tentativi, punteggio, tentativiUtenti, nomeUtente);

    StampaTentativi(tentativiUtenti);

    ScriviTentativiSuFile(tentativiUtenti, nomeUtente);

    risposta = GiocaAncora();

} while (risposta == "s" || risposta == "S");

int ScegliDifficolta()
{
    int scelta = 0;

    do
    {
        Console.WriteLine("Scegli il livello di difficolta':");
        Console.WriteLine("1. Facile (1-50, 10 tentativi)");
        Console.WriteLine("2. Medio (1-100, 7 tentativi)");
        Console.WriteLine("3. Difficile (1-200, 5 tentativi)");

        bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta);
        Console.Clear();
        if (!successoLivelloDifficolta || scelta < 1 || scelta > 3)
        {
            Console.WriteLine("Scelta non valida.");
        }
    } while (scelta < 1 || scelta > 3);

    return scelta;
}

int GeneraNumeroCasuale(int min, int max)
{
    return random.Next(min, max);
}

void IndovinaNumero(int numeroDaIndovinare, int tentativi, int punteggio, Dictionary<string, List<int>> tentativiUtenti, string nomeUtente)
{
    Console.WriteLine($"Indovina il numero! Hai {tentativi} tentativi. Punteggio massimo: {punteggio} punti.");
    bool haIndovinato = false;

    while (!haIndovinato && tentativi > 0)
    {
        Console.Write("Tentativo: ");
        if (int.TryParse(Console.ReadLine(), out int numeroUtente))
        {
            Console.Clear();
            tentativi--;

            if (!tentativiUtenti.ContainsKey(nomeUtente))
            {
                tentativiUtenti[nomeUtente] = new List<int>();
            }

            tentativiUtenti[nomeUtente].Add(numeroUtente);

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
                Console.WriteLine($"Complimenti! Hai indovinato il numero. Punteggio: {punteggio}");
                haIndovinato = true;
            }

            if (!haIndovinato && tentativi == 0)
            {
                Console.WriteLine($"Hai esaurito i tentativi. Il numero da indovinare era {numeroDaIndovinare}.");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Inserisci un numero valido.");
        }
    }
}

string ChiediNomeUtente()
{
    Console.WriteLine("Inserisci il tuo nome:");
    return Console.ReadLine();
}

void StampaTentativi(Dictionary<string, List<int>> tentativiUtenti)
{
    Console.WriteLine("Tentativi effettuati:");
    foreach (var utente in tentativiUtenti)
    {
        Console.WriteLine($"{utente.Key}: {string.Join(", ", utente.Value)}");
    }
}

void ScriviTentativiSuFile(Dictionary<string, List<int>> tentativiUtenti, string nomeUtente)
{
    string filePath = $"{nomeUtente}.txt";

    List<string> righe = new List<string>();
    foreach (var tentativoUtente in tentativiUtenti)
    {
        if (tentativoUtente.Key == nomeUtente)
        {
            righe.Add($"{tentativoUtente.Key}: {string.Join(", ", tentativoUtente.Value)}");
        }
    }

    try
    {
        File.AppendAllLines(filePath, righe);
        Console.WriteLine($"I tentativi per l'utente {nomeUtente} sono stati aggiunti nel file {filePath}.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Errore durante il salvataggio dei tentativi: {ex.Message}");
    }
}

string GiocaAncora()
{
    string risposta;
    do
    {
        Console.WriteLine("Vuoi giocare di nuovo? (s/n)");
        risposta = Console.ReadLine().ToLower();
        Console.Clear();
    } while (risposta != "s" && risposta != "n");

    return risposta;
}