// Creo la lista dei partecipanti
List<string> partecipanti = new List<string>
{
    "Adalgisa",
    "Maria",
    "Filippa",
    "Roberto",
    "Isidro",
    "Oreste",
    "Esmeralda"
};

// Creo un oggetto Random per generare il sorteggio
Random random = new Random();

// Scelgo il numero di squadre che voglio creare
ConsoleWriteLine("Inserire il numero di squadre da comporre: ");
int numeroSquadre = int Parse(ConsoleReadLine);

// Scelgo il numero di partecipanti per squadra
ConsoleWriteLine("Inserire il numero di partecipanti per squadra: ");
int partecipantiSquadra = int Parse(ConsoleReadLine);

// Divido il numero di partecipanti per ogni squadra
int partecipantiTot = numeroSquadre * partecipantiSquadra;

// Ciclo finché tutti i partecipanti sono assegnati ad una squadra
while (true)
{
    // Estraggo un indice casuale nella lista
    int index = random.Next(partecipanti.Count);

    // Seleziono il nome dalla lista in base all'indice estratto
    string partecipanteEstratto = partecipanti[index];

    // Rimuovo il partecipante estratto dalla lista
    partecipanti.RemoveAt(index);

    // Controllo se ci sono ancora partecipanti nella lista
    if (partecipanti.Count == 0)
    {
        break;
    }
}