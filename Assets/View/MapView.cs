using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour {

    // Use this for initialization
    
    public GameObject[,] obj;
    public GameObject pacman;
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
        
        obj = new GameObject[row,col];
        pacman = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        pacman.transform.position = new Vector3(GameData.pac_row, GameData.pac_col, 0);
        pacman.GetComponent<Renderer>().material.color = Color.red;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++) {
              
                if (GameData.map[i, j] == -1 )
                {
                    obj[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    obj[i, j].transform.position = new Vector3(i, j, 0);
                    obj[i, j].GetComponent<Renderer>().material.color = Color.blue;
                }
            }

        }
    }
    // Update is called once per frame
    void Update () {

        pacman.transform.position = new Vector3(Pacman.x, Pacman.y, 0);
	}
}
