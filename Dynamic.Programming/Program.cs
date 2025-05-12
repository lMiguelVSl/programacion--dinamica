using Dynamic.Programming;

//GetMinCoins();
//GetLongestLcs();
GetSuggestion();

static void GetMinCoins()
{
    int[] coins = [1, 2, 5];
    const int valueGoal = 11;
    var result = MinCoins.GetMinCoins(coins, valueGoal);

    Console.WriteLine(result != -1
        ? $"El número mínimo de monedas para alcanzar {valueGoal} es: {result}"
        : $"No se puede alcanzar la cantidad {valueGoal} con las monedas dadas.");
}

static void GetLongestLcs()
{
    var text1 = "ABCDGH";
    var text2 = "AEDFHR";
    var lengthLcs = LongestLcs.LongestCommonSubsequence(text1, text2);
    Console.WriteLine($"La LCS de '{text1}' y '{text2}' es: {lengthLcs}");

    text1 = "AGGTAB";
    text2 = "GXTXAYB";
    lengthLcs = LongestLcs.LongestCommonSubsequence(text1, text2);
    Console.WriteLine($"La LCS de '{text1}' y '{text2}' es: {lengthLcs}");
}

static void GetSuggestion()
{
    var trie = new Trie();
    string[] dishes =
        { "Pastel de manzana", "Pasta con tomate", "Ensalada de aguacate", "Pollo al horno", "Pancakes de arándanos" };

    foreach (var dish in dishes)
    {
        trie.Insert(dish);
    }

    Console.WriteLine("Escribe para obtener sugerencias (o presiona Enter para salir):");
    string input;
    while (!string.IsNullOrEmpty(input = Console.ReadLine() ?? string.Empty))
    {
        var suggestions = trie.GetSuggestions(input);
        if (suggestions.Count > 0)
        {
            Console.WriteLine("Sugerencias:");
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine($"- {suggestion}");
            }
        }
        else
        {
            Console.WriteLine("No se encontraron sugerencias.");
        }
    }
}