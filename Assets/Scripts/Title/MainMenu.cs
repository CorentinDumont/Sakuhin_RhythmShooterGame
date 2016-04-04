using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : Menu {

	override protected void OnStart(){
		Time.timeScale = 1;
		Game.current = new Game ();
		SaveLoad.Load ();
	}
}
