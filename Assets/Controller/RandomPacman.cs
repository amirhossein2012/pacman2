using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomPacman : MonoBehaviour {
  
    public static int x=0, y=0;
    public static void randomPlace()
    {
        System.Random rnd = new System.Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
        
        int row = GameData.row;
        int col = GameData.col;


        do
        {
            x = rnd.Next() % row + 1;
            y = rnd.Next() % col + 1;
        } while (GameData.map[x, y] == -1);
        GameData.pac_row = x;
        GameData.pac_col = y;
        GameData.pacx = x;
        GameData.pacy = y;
    }
}
