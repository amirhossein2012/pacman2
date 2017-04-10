using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGenerator  {
    static int row, col,wall_density;
    static int[,] map;
    static System.Random rnd ;

    public static  void generate()
    {
        row = GameData.row;
        col = GameData.col;
        wall_density = GameData.wall_density;
        map = new int[row, col];
        rnd = new System.Random();
        randomMap();
        updateData();
    }
    static void randomMap()
    {
        for(int i=0;i< row;i++)
        {
            
            for(int j = 0; j < col; j++)
            {
                if(i==0 || i==row-1 || j==0 || j == col - 1)
                {
                    map[i, j] = -1;
                    continue;
                }
                int k=rnd.Next() % 100+1;
                //should be done : check if map is valid or not
                // 
                if (k < wall_density && isValidMaze(i, j))
                {
                    map[i, j] = -1;
                }
                else if(map[i,j-1]==-1 && map[i, j + 1] == -1)
                {
                    map[i, j] = -1;
                }
                else

                {
                    map[i, j] = 1;
                }
            }
        }
    }
    static bool isValidMaze(int x, int y)
    {
        if (map[x, y - 1] == 1 && map[x, y - 2] == -1 && map[x-1,y-1] == -1)
            return false;
        if (map[x - 1, y] == 1 && (map[x - 1, y - 1] == -1 || map[x - 1, y + 1] == -1) && map[x - 2, y] == -1)
            return false;

        return true;
    }

    static void updateData()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                GameData.map[i, j] = map[i, j];
            }
        }
    }
	
}
