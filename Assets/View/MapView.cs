using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour {

    // Use this for initialization
    
    public GameObject[,] obj;
    int row, col;
    // Use this for initialization
    void initiate()
    {
        GameInitiator.Start();
        row = GameData.row;
        col = GameData.col;
       
    }
    void Start()
    {
        initiate();
        obj = new GameObject[row+1,col+1];
        char x = '0';
        for (int i = 0; i <= row; i++)
        {
            for (int j = 0; j <= col; j++) {
                if (i == 0 || i == row || j == 0 || j == col || GameData.map[i, j] == -1 )
                {
                    obj[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    obj[i, j].transform.position = new Vector3(i, j, 0);
                    obj[i, j].GetComponent<Renderer>().material.color = Color.blue;
                    obj[i, j].GetComponent<BoxCollider>().isTrigger = true;


                    obj[i, j].name = "cube" + x;
                    x = (char)((int)x + 1);
                }
            }

        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
