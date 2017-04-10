using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum Move
{
    right,left,up,down
}
public class move : MonoBehaviour {
    Pacman p;
	// Use this for initialization
	void Start () {
        p = new Pacman();
	}
    Move lastMove=Move.right;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if ((GameData.pacx - (int)GameData.pacx == 0 && GameData.pacy - (int)GameData.pacy == 0) || lastMove == Move.left)
            {
                float time = Time.time;
                p.moveLeft();
                lastMove = Move.left;
            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if ((GameData.pacx - (int)GameData.pacx == 0 && GameData.pacy - (int)GameData.pacy == 0) || lastMove == Move.right)
            {
                float time = Time.time;
                p.moveRight();
                lastMove = Move.right;
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if ((GameData.pacx - (int)GameData.pacx == 0 && GameData.pacy - (int)GameData.pacy == 0) || lastMove == Move.down)
            {
                float time = Time.time;
                p.moveDown();
                lastMove = Move.down;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if ((GameData.pacx - (int)GameData.pacx == 0 && GameData.pacy - (int)GameData.pacy == 0) || lastMove == Move.up)
            {
                float time = Time.time;
                p.moveUp();
                lastMove = Move.up;
            }

        }

        if (noWall(lastMove))
        {
            go(lastMove);
        }
        /*for(int i = 0; i < 100; i++)
        {
            if(Time.time == time + i)
            {
                p.moveRight();
            }
        }*/
    }
    bool noWall(Move lastMove)
    {
        if(lastMove == Move.right)
        {
            int k = (int)(GameData.pacx - 0.1f);
            if((float)k == GameData.pacx - 0.1f)
            {
                if (GameData.map[k, (int)GameData.pacy] != -1)
                    return true;
            }
        }
        if (lastMove == Move.left)
        {
            int k = (int)(GameData.pacx + 0.1f);
            if ((float)k == GameData.pacx+- 0.1f)
            {
                if (GameData.map[k, (int)GameData.pacy] != -1)
                    return true;
            }

        }
        if (lastMove == Move.up)
        {
            int k = (int)(GameData.pacy + 0.1f);
            if ((float)k == GameData.pacy + 0.1f)
            {
                if (GameData.map[(int)GameData.pacx, k] != -1)
                    return true;
            }

        }
        if (lastMove == Move.down)
        {
            int k = (int)(GameData.pacy - 0.1f);
            if ((float)k == GameData.pacy - 0.1f)
            {
                if (GameData.map[(int)GameData.pacx, k] != -1)
                    return true;
            }

        }
        return false;
    }
    void go(Move dir)
    {
        if(dir == Move.right)
        {
            p.moveRight();
        }
        if (dir == Move.left)
        {
            p.moveLeft();
        }
        if (dir == Move.up)
        {
            p.moveUp();
        }
        if (dir == Move.down)
        {
            p.moveDown();
        }

    }
}
