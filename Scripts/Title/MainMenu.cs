// definition of the abstract Menu class (Menu.cs)
// used for the main menu in the title scene

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : Menu {

	override protected void OnStart(){
		Time.timeScale = 1; // unpause the game (is necessary when the player comes from the main scene after having paused the game)
		Game.current = new Game (); // instantiate the Game class (that contains the data to be saved)
									// is only usefull if the load at the following line doesn't work, it is a default save
		SaveLoad.Load (); // load the game, if a save file canot be found, the new Game of the previous line will be used
	}
}
