using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	// Use this for initialization
	public static bool noWall(float x , float y)
    {
        
        if (GameData.map[(int)Mathf.Floor(x), (int)Mathf.Floor(y)] != -1 && GameData.map[(int)Mathf.Ceil(x), (int)Mathf.Ceil(y)] !=-1)
        {
            return true;
        }
        return false;
    }
    public static bool validMove(float new_x, float new_y)
    {
        if (new_x - (int)new_x != 0 && new_y - (int)new_y != 0)
            return false;
        return true;
    }
}
