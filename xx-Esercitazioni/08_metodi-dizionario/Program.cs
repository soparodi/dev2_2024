// METODI DIZIONARIO
/*
i metodi diaponibili per manipolare i dizionari sono:
- Add
- Clear
- ContainsKey
- ContainsValue
- Remove
- TryGetValue
*/

Console.Clear();

// ESEMPIO DI METODO ADD
// aggiunge un elemento a un dizionario
Dictionary<string, int> dict = new Dictionary<string, int>()
{
    {"uno", 1},
    {"due", 2},
    {"tre", 3},
};

dizionario1.Add("quattro", 4); //aggiunge "quattro" con valore 4 al dizionario1

//stampo il dizionario aggiornato
foreach (var coppia in dizionario1)
{
    Console.WriteLine($"{coppia.Key} - {coppia.Value}");
}