using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour {

    // Use this for initialization
    
    public static GameObject[,] obj;
    public static GameObject pacman,ghost1,ghost2;
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

        //creating pacman

        pacman = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        pacman.transform.position = new Vector3(GameData.pac_row, GameData.pac_col, 0);
        pacman.GetComponent<Renderer>().material.color = Color.red;

        //creating ghost

        ghost1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ghost1.transform.position = new Vector3(GameInitiator.g1.x, GameInitiator.g1.y, 0);
        ghost1.GetComponent<Renderer>().material.color = Color.green;

        ghost2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ghost2.transform.position = new Vector3(GameInitiator.g2.x, GameInitiator.g2.y, 0);
        ghost2.GetComponent<Renderer>().material.color = Color.black;

        //creating map

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++) {
              
                if (GameData.map[i, j] == -1 )
                {
                    obj[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    obj[i, j].transform.position = new Vector3(i, j, 0);
                    obj[i, j].GetComponent<Renderer>().material.color = Color.blue;
                }
                if (GameData.map[i, j] == 1)
                {
                    obj[i, j] = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                    obj[i, j].transform.position = new Vector3(i, j, 0);
                    obj[i, j].transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    obj[i, j].GetComponent<Renderer>().material.color = Color.yellow;
                }
            }

        }
    }
    // Update is called once per frame
    void Update () {

        pacman.transform.position = new Vector3(Pacman.x, Pacman.y, 0);
        ghost1.transform.position = new Vector3(GameInitiator.g1.x, GameInitiator.g1.y, 0);
        ghost2.transform.position = new Vector3(GameInitiator.g2.x, GameInitiator.g2.y, 0);
    }
}
