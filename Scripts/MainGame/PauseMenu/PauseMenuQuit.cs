using UnityEngine;
using System.Collections;

public class PauseMenuQuit : MenuChoice {

	override protected void Effect(){
		Application.Quit();
	}
}
