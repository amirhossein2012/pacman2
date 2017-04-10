using System.Collections;
using System.Collections.Generic;


public class GameInitiator  {

	// Use this for initialization
	public static void Start() {
        MapGenerator.generate();
        RandomPacman.randomPlace();
        
	}
	
	
}
