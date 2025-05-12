namespace Dynamic.Programming;

public abstract class LongestLcs
{
    public static int LongestCommonSubsequence(string texto1, string texto2)
    {
        var m = texto1.Length;
        var n = texto2.Length;

        var dp = new int[m + 1, n + 1];

        for (var i = 1; i <= m; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                if (texto1[i - 1] == texto2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        return dp[m, n];
    }
}