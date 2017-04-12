using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInput : MonoBehaviour {
    
    public enum dir

    {
        right, left, down, up ,no_dir
    }
    float start_time;
    dir d;
    // Use this for initialization
    void Start () {
        
        start_time = Time.time;
        d = dir.no_dir;
    }
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKey(KeyCode.A) )
        {
            d = dir.left;
        }
        if (Input.GetKey(KeyCode.D) )
        {
            d = dir.right;
        }
        if (Input.GetKey(KeyCode.W) )
        {
            d = dir.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            d = dir.down;
        }
        if(Time.time - start_time >= (GameData.game_speed))
        {

            if ((d == dir.right || d == dir.left) && Pacman.y - (int)Pacman.y == 0)
            {
                Pacman.move(d);
                d = dir.no_dir;
            }
            else if ((d == dir.up || d == dir.down) && Pacman.x - (int)Pacman.x == 0)
            {
                Pacman.move(d);
                d = dir.no_dir;
            }
            else
                Pacman.move(dir.no_dir);

            GameInitiator.g1.nextMove();
            GameInitiator.g2.nextMove();

            start_time = Time.time;
       
        }
        
    }
}
