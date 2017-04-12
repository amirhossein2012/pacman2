using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ghost : MonoBehaviour {
    public int grow, gcol;
    public float x, y;
    static System.Random rnd;
    float last_xchange, last_ychange;
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
    public int findPosX(int c)
    {
        return c / GameData.col;
        
    }
    public int findPosY(int c)
    {
        return c % GameData.col;

    }
    public void nextMove()
    {
        float xchange = 0, ychange = 0;

        int pac_row = Pacman.pac_row;
        int pac_col = Pacman.pac_col;

        int pacman_cell = pac_row * GameData.col + pac_col;
        int ghost_cell = grow * GameData.col + gcol;

        int next_cell = ShortestPath.next[ghost_cell, pacman_cell];
        if(x - (int)x <= GameData.eps && y - (int)y <= GameData.eps)
        {
            Debug.Log(next_cell + " " + ghost_cell);

            int a = findPosX(next_cell) - findPosX(ghost_cell);
            int b= findPosY(next_cell) - findPosY(ghost_cell);
            xchange = Pacman.speed * a;
            ychange = Pacman.speed * b;
            last_xchange = xchange;
            last_ychange = ychange;
        }
        else
        {
            xchange = last_xchange;
            ychange = last_ychange;
        }
        
        go(xchange, ychange);
    }
    public  void go(float xc, float yc)
    {

        if (Wall.validMove(x + xc, y + yc) && Wall.noWall(x + xc, y + yc))
        {
            x += xc;
            y += yc;
            if (x - (int)x <= GameData.eps && y - (int)y <= GameData.eps)
            {
                grow = (int)x;
                gcol = (int)y;

            }
            if (killPacman())
            {
                if(Pacman.health>0)
                    Pacman.initiate();
                if (Pacman.health == 0)
                {
                    Destroy(MapView.pacman);
                }
            }
        }
    }
    public bool killPacman()
    {
        if(Math.Sqrt(Mathf.Pow(x - Pacman.x,2) + Mathf.Pow(y - Pacman.y,2)) <= 1 - GameData.eps)
        {
            Pacman.health--;
            return true;
        }
        return false;
    }
}
