using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class Pacman : MonoBehaviour {
    public int pac_row, pac_col;
    public float x, y;
    public Pacman()
    {
        RandomPacman.randomPlace();
        pac_row = GameData.pac_row;
        pac_col = GameData.pac_row;
        x = pac_row;
        y = pac_col;

    }
    public void moveRight()
    {   
         x += 0.1f;
         GameData.pacx = x;
    }
}
