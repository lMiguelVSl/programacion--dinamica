namespace Dynamic.Programming;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; } = new();
    public bool IsEndOfWord { get; set; }
}

public class Trie
{
    private TrieNode _root = new();

    public void Insert(string word)
    {
        var current = _root;
        foreach (var c in word)
        {
            if (!current.Children.ContainsKey(c))
            {
                current.Children[c] = new TrieNode();
            }
            current = current.Children[c];
        }
        current.IsEndOfWord = true;
    }

    public List<string> GetSuggestions(string prefix)
    {
        var suggestions = new List<string>();
        var current = _root;

        foreach (char c in prefix)
        {
            if (!current.Children.ContainsKey(c))
            {
                return suggestions;
            }
            current = current.Children[c];
        }

        FindAllWords(current, prefix, suggestions);
        return suggestions;
    }

    private void FindAllWords(TrieNode node, string currentWord, List<string> suggestions)
    {
        if (node.IsEndOfWord)
        {
            suggestions.Add(currentWord);
        }

        foreach (var child in node.Children)
        {
            FindAllWords(child.Value, currentWord + child.Key, suggestions);
        }
    }
}