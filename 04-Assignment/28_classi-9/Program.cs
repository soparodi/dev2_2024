// Versione su GitHub_2


/*
Ogni campo utilizza il formato {Campo, -Largezza} dove:
° Campo è il valore da stampare
° -Larghezza specifica la larghezza del campo
° {"Nome", -20} significa che il nome del prodotto avrà una larghezza fissa di 20 caratteri, allineato a sinistra
Formato dei numeri:
° per i prezzi, viene usato il formato 0.00 per mostrare sempre due cifre decimali
Linea separatrice:
° La riga Console.WriteLine(new string('-', 50)); stampa una linea divisoria lunga 50 caratteri per migliorare la leggibilità
*/

public void StampaProdottiIncolonnati()
{
    // Intestazioni con larghezza fissa
    Console.WriteLine(
        $"{"ID", -5} {"Nome", -20} {"Prezzo", -10} {"Giacenza", -10}"
        );
        Console.WriteLine(new string('-', 50)); // Linea separatrice

        // Stampa ogni prodotto con larghezza fissa
        foreach (var prodotto in prodotti)
        {
            Console.WriteLine(
                $"{prodotto.Id, -5} {prodotto.NomeProdotto, -20} {prodotto.PrezzoProdotto, -10:0.00} {prodotto.GiacenzaProdotto, -10}"
                );
        }
}