using UnityEngine;
using System.Collections;

public class PauseMenuContinue : MenuChoice {

	public PauseMenuWrapper pauseMenuWrapper;

	override protected void Effect(){
		pauseMenuWrapper.TogglePause ();
	}
}
