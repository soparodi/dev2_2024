# Calcolatrice semplice

## Versione 1

## Obiettivo

- Scrivere un programma che simuli una calcolatrice semplice.
- L utente deve poter inserire due numeri e selezionare un operatore matematico (+, -, *, /)
- Il programma deve eseguire l'operazione selezionata e stampare il risultato.
- Il programma non gestisce nessun tipo di errore o di eccezione.

```csharp
// Chiedi all'utente di inserire due numeri
Console.Write("Inserisci il primo numero: ");
double num1 = Convert.ToDouble(Console.ReadLine());
Console.Write("Inserisci il secondo numero: ");
double num2 = Convert.ToDouble(Console.ReadLine());
// Chiedi all'utente di selezionare un operatore matematico
Console.Write("Seleziona un operatore (+, -, *, /): ");
// char operatore = Convert.ToChar(Console.ReadLine());
// usando il char posso usare il readkey per leggere un solo carattere
char operatore = Console.ReadKey().KeyChar; // restituisce il carattere premuto dall'utente senza dover premere invio
Console.WriteLine();
// Esegui l'operazione selezionata
double risultato = 0;
switch (operatore)
{
    case '+':
        risultato = num1 + num2;
        break;
    case '-':
        risultato = num1 - num2;
        break;
    case '*':
        risultato = num1 * num2;
        break;
    case '/':
        risultato = num1 / num2;
        break;
    default:
        Console.WriteLine("Operatore non valido.");
        break;
}
// Stampa il risultato
Console.WriteLine($"Il risultato dell'operazione è: {risultato}");
```

## Comandi di versionamento

```bash
git add --all
git commit -m "Implement calcolatrice semplice"
git push
```

# Versione 2

## Obiettivo

- Aggiungere la gestione degli errori per evitare crash del programma.
- Se l'utente inserisce un valore non numerico, il programma deve stampare un messaggio di errore dicendo di inserire un numero valido
- Se l'utente seleziona un operatore non valido, il programma deve stampare un messaggio di errore dicendo di selezionare un operatore valido
- Se l'utente tenta di dividere per zero, il programma deve stampare un messaggio di errore dicendo che la divisione per zero non è consentita
- Il programma deve usare i blocchi try-catch per gestire gli errori

```csharp

```