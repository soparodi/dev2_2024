## GENERATORE DI PASSWORD

## Obiettivo

Programma in C# che genera una password sicura basata sui seguenti criteri:

- La lunghezza della password deve essere compresa tra 8 e 20 caratteri
- La password deve contenere almeno:

    - 1 lettera maiuscola
    - 1 lettera minuscola
    - 1 numero
    - 1 carattere speciale

- La password non deve contere spazi.

## Suggerimenti

- Usa la classe Random per generare caratteri casuali.
- Puoi creare gruppi di caratteri e selezionare casualmente un carattere da ciascun gruppo.

## Versione 1

```csharp
string GeneraPassword(int lunghezza)
{
    if (lunghezza < 8 || lunghezza > 20)
        return "Errore: la lunghezza deve essere tra 8 e 20 caratteri.";

    // Creo dei gruppi di caratteri elencandoli per categoria
    string lettereMaiuscole = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string lettereMinuscole = "abcdefghijklmnopqrstuvwxyz";
    string numeri = "0123456789";
    string caratteriSpeciali = "!@#$%^&*()-_=+[]{};:,.<>? ";
    string tuttiCaratteri = lettereMaiuscole + lettereMinuscole + numeri + caratteriSpeciali;

    // Stringa per costruire la password
    string password = "";

    Random random = new Random();

    // Aggiungo almeno un carattere casuale da ciascun gruppo
    password += lettereMaiuscole[random.Next(lettereMaiuscole.Length)];
    password += lettereMinuscole[random.Next(lettereMinuscole.Length)];
    password += numeri[random.Next(numeri.Length)];
    password += caratteriSpeciali[random.Next(caratteriSpeciali.Length)];

    // Aggiungo altri caratteri casuali fino alla lunghezza desiderata
    for (int i = password.Length; i < lunghezza; i++)
    {
        password += tuttiCaratteri[random.Next(tuttiCaratteri.Length)];
    }

    // Restituisco la stringa della password generata
    return password;
}

// Genero una password con il numero di caratteri che voglio
int lunghezzaPassword = 10; // Devo mettere un numero tra 8 e 20 se no non la genera
string passwordSicura = GeneraPassword(lunghezzaPassword);

// Controllo se la funzione ha restituito un errore o una password valida
if (passwordSicura.StartsWith("Errore:"))
{
    Console.WriteLine(passwordSicura); // Mostra il messaggio di errore
}
else if (passwordSicura.Contains(" "))
{
    Console.WriteLine("Errore: La password non è valida.");
}
else
{
    Console.WriteLine($"Password: {passwordSicura}");
}
```