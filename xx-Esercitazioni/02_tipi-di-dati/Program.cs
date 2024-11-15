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


// METODI DI STRINGA
// i tipi di dato stringa hanno dei metodi che permettono di eseguire delle operazioni su di essi o ottenere info su di essi

// lenght
// prende la lunghezza di una stringa
string nome2 = "nome";
Console.WriteLine(nome2.Length);

// verifica che non ci sia uno spazio vuoto
string nome3 = "nome";
Console.WriteLine(string.IsNullOrWhiteSpace); // output: false - se è true, allora l'utente ha inserito uno spazio vuoto

// tolower
string nome4 = "nome";
Console.WriteLine(nome4.ToLower()); // tutto in minuscolo - nome

// toupper
string nome5 = "nome";
Console.WriteLine(nome5.ToUpper()); // tutto in maiuscolo - NOME

// trim
string nome6 = "nome";
Console.WriteLine(nome6.Trim()); // rimuove gli spazi prima e dopo la stringa (non in mezzo)

// split
// divide una stringa in base a un separatore
// tolower
string nomi1 = "nome1, nome2, nome3";
string[] nomi2 = nomi1.Split(',');

foreach (string nomi in nomi2)
{
Console.WriteLine(nome4.ToLower()); // tutto in minuscolo
}

// replace
// sostituisce una stringa in una sottostringa
string nome7 = "nome";
Console.WriteLine(nome7.Replace("nome, nome1")); // output: nome1

// substring
string nome8 = "nome";
Console.WriteLine(nome7.Substring(0, 3)); // output: nom

// contains
// verifica se contiene una sottostringa
string nome9 = "nome";
Console.WriteLine(nome9.Contains("nom")); // output: true

// indexof
// restituisce l'indice della prima occorrenza di una sottostringa
// se non trova la sottostringa restituisce -1
// se trova piu occorrenze restituisce l'indice della prima occorrenza
string nome10 = "nome";
Console.WriteLine(nome10.IndexOf("nome"));

// lastindexof
// restituisce l'indice dell'ultima sottostringa
// parte dalla fine della stringa
string nome11 = "nome";
Console.WriteLine(nome11.LastIndexOf("o")); // output: 3 - terzo carattere partendo da destra (dalla fine)

// startswith
// verifica se una stringa inzia con una sottostringa
string nome12 = "nome";
Console.WriteLine(nome12.StartsWith("n")); // output: true

// endswith
// verifica se una stringa finisce con una sottostringa
string nome13 = "nome";
Console.WriteLine(nome13.EndsWith("e")); // output: true

/* conversione implicita da int a double
   conversione esplicita da double a int */

/* tostring/toint - parse - try parse
- da dato a stringa (funziona con int, double, char, ecc.) / da stringa a intero
- parse
- oltre a convertire, restituisce un booleano (es.: out)
*/

// convert
// converte un altro tipo di dato (es. stringa) in un altro tipo di dato (es. int)
// ToInt32
// startswith
// verifica se una stringa inzia con una sottostringa
string eta = "10";
Console.WriteLine(Convert.ToInt32(eta)); // output: 10

// concatenazione con string.format
/* stampa per indice, simile al PRINT F di C (Arduino)
qualora uno voglia ordinarle per indice */


