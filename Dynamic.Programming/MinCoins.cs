namespace Dynamic.Programming;

public abstract class MinCoins
{
    public static int GetMinCoins(int[] coins, int amount)
    {
        var dp = new int[amount + 1];

        dp[0] = 0;

        for (var i = 1; i <= amount; i++)
        {
            dp[i] = amount + 1;
        }

        for (var i = 1; i <= amount; i++)
        {
            foreach (var coin in coins)
            {
                if (coin <= i)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }

        return dp[amount] > amount ? -1 : dp[amount];
    }
}