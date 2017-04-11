using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData  {
    //Game database
    public static int row, col, square_size, wall_density,pac_row,pac_col;
    public static float pacx, pacy, game_speed;

    public static int[,] map;
    public static void initiate()
    {
        row = GameModelLoader.row;
        col = GameModelLoader.col;
        square_size = GameModelLoader.square_size;
        wall_density = GameModelLoader.wall_density;
        game_speed = GameModelLoader.game_speed;
        map = new int[row, col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                map[i, j] = 0;
            }
        }
    }
    static GameData()
    {
        initiate();
    }

	
	
}
