// CONDIZIONI
/* Le principali istruzioni di controllo sono:
- if
- else
- else if
- switch
*/

// pulisce la console
Console.Clear();
// ESEMPIO DI IF
// se una condizione viene soddisfatta esegue un blocco di codice (tra {})
int v = 1;
if (v > 5)
{
    Console.WriteLine("v e maggiore di 5");
}

// ESEMPIO DI IF ELSE
// se una condizione viene soddisfatta esegue un blocco di codice altrimenti ne esegue un altro

int w = 1;
if (w > 5)
{
    Console.WriteLine("v e maggiore di 5");
}
else
{
    Console.WriteLine("v e minore o uguale a 5");
}

// ESEMPIO DI IF ESLSE IF
// se una condizione viene soddisfatta esegue un blocco di codice altrimenti ne esegue un altro, o un altro ancora se nessuna condizione e vera
int x = 10;
if (x > 5)
{
    Console.WriteLine("x e maggiore di 5");
}
else if (x == 5)
{
    Console.WriteLine("x e uguale a 5");
}
else 
{
    Console.WriteLine("x e minore di 5");
}
// else if va messo in mezzo tra if e else altrimenti non lo esegue