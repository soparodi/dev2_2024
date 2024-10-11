// questo è un commento a riga singola

/*
questo è un commento a riga multipla
*/

// il metodo Console.Writeline stampa a video il testo passato come argomento
Console.WriteLine("Ciao!"); // questo è un commento a fine riga
Console.WriteLine(".");
// il metodo Console.Readline legge una riga di testo da tastiera
Console.WriteLine("Inserisci il tuo nome");
string nome = Console.ReadLine(); // legge una riga di testo e la assegna alla variabile nome
// stampo il nome concatenato con una stringa
Console.WriteLine("Ciao " + nome + "!"); // con il segno + posso concatenare stringhe con variabili
// stampo il nome concatenato con una stringa utilizzando l'interpolazione
Console.WriteLine("Inserisci il tuo cognome");
string cognome = Console.ReadLine();
Console.WriteLine($"Ciao {nome} {cognome}!"); // con l'interpolazione posso concatenare più variabili in modo semplificato
Console.WriteLine($"Ciao {nome.ToUpper()}!"); // con il metodo To Upper() trasforma una riga in maiuscolo
Console.WriteLine($"Ciao {nome.ToLower()}!"); // con il metodo To Lower() trasforma una riga in minuscolo
// chiedo all'utente di inserire l'età
Console.WriteLine("Inserisci la tua età");
// leggo l'età da tastiera e la assegno alla variabile età
string età = Console.ReadLine();
// stampo l'età
Console.WriteLine($"Hai {età} anni.");
//stampo nome cognome ed età concatenati
Console.WriteLine($"Ciao {nome} {cognome}! Hai {età} anni.");
// dichiaro una variabile intera etàInt
int etàInt = 35;
string etàStr = etàInt.ToString();
// concateno etàInt con una stringa
Console.WriteLine($"Hai {etàInt} anni.");

/*
i metodi di console permettono di gestire l'output o l'input (il dialogo con l'utente) attraverso la console
WriteLine() stampa a video una stringa
ReadLine() legge una stringa da tastiera

ho utilizzato due variabili di tipo string per memorizzare il nome e cognome dell'utente
ho utilizzato una variabile di tipo string per memorizzare l'età dell'utente

il metodo ToUpper() trasforma una riga in maiuscolo
il metodo ToLower() trasforma una riga in minuscolo

ho provato ad utilizzare la variabile intera direttamente ma mi ha dato errore perché doveva esserea convertita in stringa
ho utilzzato il metodo To String() per convertire un intero in una stringa e l'ho interpolata
*/
// modificato