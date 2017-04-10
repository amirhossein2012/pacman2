using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    Pacman p;
	// Use this for initialization
	void Start () {
        p = new Pacman();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            float time = Time.time;
            p.moveRight();

        }
        
        /*for(int i = 0; i < 100; i++)
        {
            if(Time.time == time + i)
            {
                p.moveRight();
            }
        }*/
	}
}
