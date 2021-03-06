﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class Pacman : MonoBehaviour {
    public static int pac_row, pac_col;
    public static float x, y;
    public static float speed = 0.5f;
    public static GetInput.dir last_dir;
    public static void initiate()
    {
        RandomPacman.randomPlace();
        pac_row = GameData.pac_row;
        pac_col = GameData.pac_col;
        x = pac_row;
        y = pac_col;
        Debug.Log(x + " " + y);
    }
    public static void move(GetInput.dir dir)
    {
        float xchange = 0, ychange = 0;
        if(dir == GetInput.dir.no_dir)
        {
            dir = last_dir;
        }
        if(dir == GetInput.dir.right)
        {
            xchange = speed;
            last_dir = dir;
        }
        else if (dir == GetInput.dir.left)
        {
            xchange = -speed;
            last_dir = dir;
        }
        else if (dir == GetInput.dir.up)
        {
            ychange = speed;
            last_dir = dir;
        }
        else if (dir == GetInput.dir.down)
        {
            ychange = -speed;
            last_dir = dir;
        }
        go(xchange, ychange);
        
    }
    public static bool validMove(float new_x , float new_y)
    {
        if (new_x - (int)new_x != 0 && new_y - (int)new_y != 0)
            return false;
        return true;
    }
    public static void go(float xc , float yc)
    {
        
        if(validMove(x+xc , y+yc) && Wall.noWall(x + xc , y + yc))
        {
            x += xc;
            y += yc;
            if(x - (int)x ==0 && y - (int)y == 0)
            {
                pac_row =(int) x;
                pac_col = (int) y;
                eat(pac_row,pac_col);
            }
        }
    }
    private static void eat(int a, int b)
    {
        if (GameData.map[a, b] > 0)
        {
            GameData.map[a, b] = 0;
            Destroy(MapView.obj[a, b]);

        }
    }
    

}
