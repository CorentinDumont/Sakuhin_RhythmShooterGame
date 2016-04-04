using UnityEngine;
using System.Collections;

public class MainMenuQuit : MenuChoice {

	override protected void Effect(){
		Application.Quit ();
	}
}
