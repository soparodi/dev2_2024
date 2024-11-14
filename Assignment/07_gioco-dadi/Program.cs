string risposta = "";

do
{
    // Lancio dado utente
    Random random = new Random();
int dadoUtente = random.Next(1, 7); // genero un numero casuale tra 1 e 6

Console.WriteLine("Lancia il dado: ");

string lancioDado;

lancioDado = Console.ReadLine();

Console.WriteLine("e uscito " + dadoUtente);

// Lancio dado computer
Random random1 = new Random();
int dadoComputer = random1.Next(1, 7);

Console.WriteLine("Ora lancia il computer: ");

string lancioDado1;

lancioDado1 = Console.ReadLine();

Console.WriteLine("e uscito " + dadoComputer);

if (dadoUtente > dadoComputer)
{
    Console.WriteLine("Hai vinto!");
}
else if (dadoUtente < dadoComputer)
{
    Console.WriteLine("Hai perso");
}
else
{
    Console.WriteLine("Pareggio");
}

// Chiedo all'utente se vuole giocare di nuovo
risposta = "s"; // inizializzo la risposta a "s" per far partire il gioco


Console.WriteLine("Vuoi giocare di nuovo? (s/n)");
risposta = Console.ReadLine();

while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
{
    Console.WriteLine("Risposta non valida. Vuoi giocare di nuovo? (s/n)");
    risposta = Console.ReadLine();
}

} while (risposta == "s" || risposta == "S") ;