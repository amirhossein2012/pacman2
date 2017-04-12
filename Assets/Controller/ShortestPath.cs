using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortestPath : MonoBehaviour {

    public static int[,] dp;
    public static int[,] next;
    public static int[,] table;
    public static void initiate()
    {
        dp = new int[GameData.row * GameData.col, GameData.row * GameData.col];
        next = new int[GameData.row * GameData.col, GameData.row * GameData.col]; 
        table = new int[GameData.row , GameData.col];
        initiate2();
        allPairShortestPath(GameData.row * GameData.col);
    }
    private static void initiate2()
    {
        int inf = 1000 * 1000;
        int l = GameData.row;
        for (int i = 0; i < GameData.row; i++)

            for (int j = 0; j < GameData.col; j++)
            {
                table[i,j] = GameData.map[i,j];
            }
        for (int i = 0; i < GameData.row * GameData.col; i++)
        {
            for (int j = 0; j < GameData.row * GameData.col; j++)
            {
                dp[i,j] = inf;
                dp[i,i] = 0;

            }
        }
        for (int i = 0; i < GameData.row; i++)
        {
            for (int j = 0; j < GameData.col; j++)
            {
                int k = i * GameData.col + j;
                if (i > 0)
                {
                    if (table[i,j] != table[i - 1,j])
                    {
                        dp[k,k - l] = inf;
                        dp[k - l,k] = inf;
                        
                    }
                    else
                    {
                        dp[k,k - l] = 1;
                        dp[k - l,k] = 1;

                    }

                    next[k,k - l] = k - l;

                    next[k - l,k] = k;
                }
                if (j > 0)
                {
                    if (table[i,j] != table[i,j - 1])
                    {
                        dp[k,k - 1] = inf;
                        dp[k - 1,k] = inf;

                    }
                    else
                    {
                        dp[k,k - 1] = 1;
                        dp[k - 1,k] = 1;
                    }
                    next[k,k - 1] = k - 1;
                    next[k - 1,k] = k;
                }
            }
        }
        
    }
    private static void allPairShortestPath(int n)
    {
        int k, i, j;
        int l = GameData.row;

        for (k = 0; k < n; k++)
        {
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (dp[i,k] + dp[k,j] < dp[i,j])
                    {
                        dp[i,j] = dp[i,k] + dp[k,j];

                    }
                }
            }
        }
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                if (i > l)
                {
                    if (dp[i,j] == dp[i - l,j] + 1)
                    {
                        next[i,j] = i - l;
                    }
                }
                if (i < n - l)
                {
                    if (dp[i,j] == dp[i + l,j] + 1)
                    {
                        next[i,j] = i + l;
                    }
                }
                if (i % l > 0)
                {
                    if (dp[i,j] == dp[i - 1,j] + 1)
                    {
                        next[i,j] = i - 1;
                    }
                }
                if (i % l < l - 1)
                {
                    if (dp[i,j] == dp[i + 1,j] + 1)
                        next[i,j] = i + 1;
                }
            }
        }
    }
}
