using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomPacman : MonoBehaviour {
    static System.Random rnd;
    public static int x=0, y=0;
    public static void randomPlace()
    {
        rnd = new System.Random();
        
        int row = GameData.row;
        int col = GameData.col;
        while (GameData.map[x, y] == -1)
        {
            x = rnd.Next() % row + 1;
            y = rnd.Next() % col + 1;
        }
        GameData.pac_row = x;
        GameData.pac_col = y;
        GameData.pacx = x;
        GameData.pacy = y;
    }
}
