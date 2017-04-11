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
}
