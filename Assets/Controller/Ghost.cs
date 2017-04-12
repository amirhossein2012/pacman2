using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ghost : MonoBehaviour {
    public int grow, gcol;
    public float x, y;
    static System.Random rnd;
    public Ghost()
    {

        rnd = new System.Random(((int)DateTime.Now.Ticks & 0x0000FFFF));

        int row = GameData.row;
        int col = GameData.col;
        
        do{
            grow = rnd.Next() % row + 1;
            gcol = rnd.Next() % col + 1;
        } while (GameData.map[grow, gcol] == -1 || (grow == GameData.pac_row && gcol == GameData.pac_col)) ;
            x = grow;
        y = gcol;
        GameData.map[grow, gcol] = -1;

    }
    public void nextMove()
    {
        float xchange = 0, ychange = 0;
        rnd = new System.Random();
        int k = rnd.Next() % 4;
        if( k == 0)
        {
            xchange = Pacman.speed;
        }
        if (k == 1)
        {
            xchange = -Pacman.speed;
        }
        if (k == 2)
        {
            ychange = Pacman.speed;
        }
        if (k == 3)
        {
            ychange = -Pacman.speed;
        }
        go(xchange, ychange);
    }
    public  void go(float xc, float yc)
    {

        if (Wall.validMove(x + xc, y + yc) && Wall.noWall(x + xc, y + yc))
        {
            x += xc;
            y += yc;
            if (x - (int)x == 0 && y - (int)y == 0)
            {
                grow = (int)x;
                gcol = (int)y;

            }
            if (killPacman())
            {
                Pacman.initiate();
            }
        }
    }
    public bool killPacman()
    {
        if(Math.Sqrt(Mathf.Pow(x - Pacman.x,2) + Mathf.Pow(y - Pacman.y,2)) <= 0.97f)
        {
            return true;
        }
        return false;
    }
}
