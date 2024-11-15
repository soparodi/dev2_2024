// i tipi di dati semplici

// variabili di tipo intero
int eta = 10; // dichiarazione e inizializzazione di una variabile di tipo intero

int eta2; // dichiarazione di una variabile di tipo intero
eta2 = 10; // inizializzazione di una variabile di tipo intero

// variabili di tipo decimale
double altezza = 1.70; // dichiarazione e inizializzazione di una variabile di tipo decimale

// variabili di tipo carattere
char iniziale = 'M'; // dichiarazione e inizializzazione di una variabile di tipo carattere

// variabili di tipo stringa
string nome = "Mario"; // dichiarazione e inizializzazione di una variabile di tipo stringa

// variabili di tipo booleano
bool maggiorenne = true; // dichiarazione e inizializzazione di una variabile di tipo booleano

var cognome = "Rossi"; //è compile time: non può cambiare tipo e deve essere inizializzata al momento della dichiarazione

dynamic altezza = 1,70; // è runtime: può cambiare tipo e non necessita di essere inizializzata

// variabili di tipo data
DateTime dataNascita = new DateTime(2000,1,1); // dichiarazione e inizializzazione di una variabile di tipo data

// esempio di utilizzo di una variabile attraverso i metodi di console
// utilizzando l'interpolazione di stringhe
Console.WriteLine($"La variabile eta contiene il valore {eta}"); // output 10
Console.WriteLine($"La variabile eta contiene il valore {altezza}"); // output 1.7

// ricevo l'input dall utente e lo salvo in una variabile
Console.WriteLine("Inserisci il tuo nome: ");
string nomeUtente = Console.ReadLine();
Console.WriteLine($"Ciao {nomeUtente}!"); // output: Ciao Mario!

// I TIPI DI DATI COMPLESSI (o strutture di dati)
// un insieme di dati dello stesso tipo

// ARRAY
int[] numeri = new int[5]; // dichiarazione e inizializzazione di un array di interi di 5 elementi
                            // new e una parola chiave che serve per creare un nuovo oggetto (costruttore)
// inserimento di valori di un array
numeri[0] = 10;
numeri[1] = 20;
numeri[2] = 30;
numeri[3] = 40;
numeri[4] = 50;

// inserimento di valori multipli nell array
int[] numeri2 = new int[] {10,20,30,40,50}; // dichiarazione e inizializzazione di un array di interi di 5 elementi

// la caratteristica degli array e che sono di dimensione fissa

// LISTA
List<int> numeri3 = new List<int>(); // dichiarazione di una lista di interi
// la caratteristica delle liste e che sono di dimensione variabile

// inserimento di valori nella lista
numeri3.Add(10); // inserisco il valore nella lista usando il metodo Add
numeri3.Add(20);
numeri3.Add(30);
numeri3.Add(40);
numeri3.Add(50);

// inserimento di valori multipli nella lista
List<int> numeri4 = new List<int> {10,20,30,40,50}; // dichiarazione e inizializzazione di una lista di interi di 5 elementi

// sia le liste che gli array sono collezioni di dati che possono essere di Int, Double, Char, String, ecc.
// esempio di lista di string
List<string> nomi = new List<string> {"Mario", "Luigi", "Peach"}; // dichiarazione e inizializzazione di una lista di stringhe

// DIZIONARIO
Dictionary<string, int> voti = new Dictionary<string, int>(); // dichiarazione di un dizionario con chiave di tipo stringa e un valore di tipo intero
// in questo caso string e la chiave e int il valore, cioe una associazione di due elementi

// BEST PRACTICES PER LA DICHIARAZIONE DELLE VARIABILI
// dichiarare le variabili con nomi significativi
// dichiarare le variabili con la notazione CamelCase o PascalCase
// esempio CamelCase etaStudente
// esempio PascalCase EtaStudente
