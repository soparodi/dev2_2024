// Benvenuto e introduzione al programma
Console.WriteLine("** Benvenuto nel Programma del Supermercato **");

// 1. Inizializzazione dei dati principali (Prodotti, Clienti, ecc.)
// Lista dei prodotti disponibili nel magazzino
List<Prodotto> magazzino = new List<Prodotto>
{
    new Prodotto(1, "Mela", 0.5, 100), // Prodotto con ID=1, nome="Mela", prezzo=0.5€, giacenza=100
    new Prodotto(2, "Pane", 1.0, 50)   // Prodotto con ID=2, nome="Pane", prezzo=1.0€, giacenza=50
};

// Lista dei dipendenti iniziali
List<Dipendente> dipendenti = new List<Dipendente>
{
    new Dipendente(1, "Adalgisa", "Amministratore"),   // Admin principale
    new Dipendente(2, "Camilla", "Cassiere"),         // Dipendente Cassiere
    new Dipendente(3, "Oreste", "Magazziniere")     // Dipendente Magazziniere
};

// Lista dei clienti
List<Cliente> clienti = new List<Cliente>
{
    new Cliente(1, "cliente1") // Cliente iniziale con ID=1
};

// Variabili ausiliarie
int prossimoIdAcquisto = 1; // Contatore per generare ID univoci per gli acquisti
List<Acquisto> acquisti = new List<Acquisto>(); // Lista per memorizzare gli acquisti completati

// 2. Menu principale
bool esci = false;
while (!esci)
{
    Console.WriteLine("\n** Menu Principale **");
    Console.WriteLine("1. Cassiere");
    Console.WriteLine("2. Magazziniere");
    Console.WriteLine("3. Amministratore");
    Console.WriteLine("4. Cliente");
    Console.WriteLine("5. Esci");

    int scelta = InputManager.LeggiIntero("Seleziona il ruolo (1-5): ", 1, 5);

    // Switch per gestire i ruoli
    switch (scelta)
    {
        case 1: GestioneCassiere(); break;
        case 2: GestioneMagazziniere(); break;
        case 3: GestioneAmministratore(); break;
        case 4: GestioneCliente(); break;
        case 5:
            Console.WriteLine("Arrivederci!");
            esci = true;
            break;
    }
}

// 3. Gestione dei Ruoli
// Gestione del ruolo "Cassiere"
void GestioneCassiere()
{
    Console.WriteLine("** Gestione Cassa **");

    // Scansiona gli acquisti completati
    foreach (Acquisto acquisto in acquisti)
    {
        if (acquisto.Stato == "Completato")
        {
            double totale = 0; // Calcolo del totale dell'acquisto

            // Somma il prezzo dei prodotti
            foreach (Prodotto prodotto in acquisto.Prodotti)
            {
                totale += prodotto.Prezzo;
            }

            // Stampa il totale e aggiorna lo stato
            Console.WriteLine($"Acquisto ID: {acquisto.Id} - Totale: €{totale:F2}");
            acquisto.Stato = "Processato";
        }
    }
}

// Gestione del ruolo "Magazziniere"
void GestioneMagazziniere()
{
    Console.WriteLine("** Gestione Magazzino **");
    Console.WriteLine("1. Visualizza Prodotti");
    Console.WriteLine("2. Aggiungi Prodotto");

    int scelta = InputManager.LeggiIntero("Scelta: ", 1, 2);

    if (scelta == 1)
    {
        // Visualizza i prodotti esistenti
        foreach (Prodotto p in magazzino)
        {
            Console.WriteLine($"{p.Id} - {p.Nome} (€{p.Prezzo:F2}) - Giacenza: {p.Giacenza}");
        }
    }
    else if (scelta == 2)
    {
        // Aggiunta di un nuovo prodotto
        string nome = InputManager.LeggiStringa("Nome prodotto: ");
        double prezzo = InputManager.LeggiDecimale("Prezzo: ", 0);
        int giacenza = InputManager.LeggiIntero("Giacenza: ", 0);
        magazzino.Add(new Prodotto(magazzino.Count + 1, nome, prezzo, giacenza));
        Console.WriteLine("Prodotto aggiunto con successo.");
    }
}

// Gestione del ruolo "Amministratore"
void GestioneAmministratore()
{
    Console.WriteLine("** Gestione Dipendenti **");
    Console.WriteLine("1. Visualizza Dipendenti");
    Console.WriteLine("2. Aggiungi Dipendente");

    int scelta = InputManager.LeggiIntero("Scelta: ", 1, 2);

    if (scelta == 1)
    {
        // Visualizza tutti i dipendenti
        foreach (Dipendente d in dipendenti)
        {
            Console.WriteLine($"ID: {d.Id}, Username: {d.Username}, Ruolo: {d.Ruolo}");
        }
    }
    else if (scelta == 2)
    {
        // Aggiunta di un nuovo dipendente
        string username = InputManager.LeggiStringa("Username: ");
        string ruolo = InputManager.LeggiStringa("Ruolo (Cassiere/Magazziniere/Amministratore): ");
        dipendenti.Add(new Dipendente(dipendenti.Count + 1, username, ruolo));
        Console.WriteLine("Dipendente aggiunto con successo.");
    }
}

// Gestione del ruolo "Cliente"
void GestioneCliente()
{
    Cliente cliente = clienti[0]; // Usa il primo cliente come esempio
    Console.WriteLine($"Benvenuto, {cliente.Username}");

    Console.WriteLine("1. Aggiungi Prodotto al Carrello");
    Console.WriteLine("2. Visualizza Carrello");
    Console.WriteLine("3. Finalizza Acquisto");

    int scelta = InputManager.LeggiIntero("Scelta: ", 1, 3);

    if (scelta == 1)
    {
        // Visualizza prodotti disponibili
        foreach (Prodotto p in magazzino)
        {
            Console.WriteLine($"{p.Id} - {p.Nome} (€{p.Prezzo:F2}) - Giacenza: {p.Giacenza}");
        }

        // Aggiunta al carrello
        int idProdotto = InputManager.LeggiIntero("ID prodotto: ", 1, magazzino.Count);
        foreach (Prodotto p in magazzino)
        {
            if (p.Id == idProdotto && p.Giacenza > 0)
            {
                cliente.Carrello.Add(p);
                p.Giacenza--;
                Console.WriteLine("Prodotto aggiunto al carrello.");
                break;
            }
        }
    }
    else if (scelta == 2)
    {
        // Visualizza i prodotti nel carrello
        foreach (Prodotto p in cliente.Carrello)
        {
            Console.WriteLine($"{p.Nome} - €{p.Prezzo:F2}");
        }
    }
    else if (scelta == 3)
    {
        // Finalizza l'acquisto
        acquisti.Add(new Acquisto(prossimoIdAcquisto++, cliente.Id, cliente.Carrello.ToArray()));
        cliente.Carrello.Clear();
        Console.WriteLine("Acquisto completato!");
    }
}

// Classi principali
public class Prodotto
{
    public int Id { get; }
    public string Nome { get; set; }
    public double Prezzo { get; set; }
    public int Giacenza { get; set; }

    public Prodotto(int id, string nome, double prezzo, int giacenza)
    {
        Id = id;
        Nome = nome;
        Prezzo = prezzo;
        Giacenza = giacenza;
    }
}

public class Dipendente
{
    public int Id { get; }
    public string Username { get; set; }
    public string Ruolo { get; set; }

    public Dipendente(int id, string username, string ruolo)
    {
        Id = id;
        Username = username;
        Ruolo = ruolo;
    }
}

public class Cliente
{
    public int Id { get; }
    public string Username { get; set; }
    public List<Prodotto> Carrello { get; } = new List<Prodotto>();

    public Cliente(int id, string username)
    {
        Id = id;
        Username = username;
    }
}

public class Acquisto
{
    public int Id { get; }
    public int ClienteId { get; }
    public Prodotto[] Prodotti { get; }
    public string Stato { get; set; } = "Completato";

    public Acquisto(int id, int clienteId, Prodotto[] prodotti)
    {
        Id = id;
        ClienteId = clienteId;
        Prodotti = prodotti;
    }
}

// Gestione input utente
public static class InputManager
{
    public static int LeggiIntero(string messaggio, int min, int max)
    {
        while (true)
        {
            Console.Write(messaggio);
            int valore;
            if (int.TryParse(Console.ReadLine(), out valore) && valore >= min && valore <= max)
                return valore;
            Console.WriteLine("Input non valido.");
        }
    }

    public static double LeggiDecimale(string messaggio, double min)
    {
        while (true)
        {
            Console.Write(messaggio);
            double valore;
            if (double.TryParse(Console.ReadLine(), out valore) && valore >= min)
                return valore;
            Console.WriteLine("Input non valido.");
        }
    }

    public static string LeggiStringa(string messaggio)
    {
        while (true)
        {
            Console.Write(messaggio);
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input;
            Console.WriteLine("Input non valido.");
        }
    }
}