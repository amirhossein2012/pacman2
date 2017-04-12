using System.Collections;
using System.Collections.Generic;


public class GameInitiator  {
    public static Ghost g1,g2;
	// Use this for initialization
	public static void Start() {
        MapGenerator.generate();
        
        Pacman.initiate();
        ShortestPath.initiate();
        g1 = new Ghost();
        g2 = new Ghost();
        GameData.map[g1.grow, g1.gcol] = 1;
        GameData.map[g2.grow, g2.gcol] = 1;
    }
	
	
}
