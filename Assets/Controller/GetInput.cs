using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInput : MonoBehaviour
{

    public enum dir

    {
        right, left, down, up, no_dir
    }
    float start_time, start_time2 , start_time3;
    dir d;
    // Use this for initialization
    void Start()
    {

        start_time = Time.time;
        start_time2 = Time.time;
        start_time3 = Time.time;
        d = dir.no_dir;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pacman.health > 0 && GameData.food_count > 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                d = dir.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                d = dir.right;
            }
            if (Input.GetKey(KeyCode.W))
            {
                d = dir.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                d = dir.down;
            }
            if (Time.time - start_time >= (GameData.game_speed))
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

                start_time = Time.time;

            }
            if (Time.time - start_time2 >= (GameData.game_speed) * 1.5f)
            {

                GameInitiator.g1.nextMove();
                
                start_time2 = Time.time;
            }
            if (Time.time - start_time3 >= (GameData.game_speed) * 1.8f)
            {

                
                GameInitiator.g2.nextMove();
                start_time3 = Time.time;
            }
            if (Pacman.health == 0)
                Destroy(MapView.pacman);
        }
    }

    public void OnGUI()
    {
        string s = "Health : "+Pacman.health.ToString();
        GUI.TextArea(new Rect(0, 0, 70, 20),s);
        if (GameData.food_count <= 0)
        {
            GUI.TextArea(new Rect(300, 292, 100, 20), "YOU WIN");

        }
        if(Pacman.health <= 0)
        {
            GUI.TextArea(new Rect(300, 292,100, 20), "YOU LOST");
        }
    }
}
