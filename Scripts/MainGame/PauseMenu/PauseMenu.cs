// definition of the abstract Menu class (Menu.cs)
// used for the pause menu in the main scene of the game
// it doesn't do anything special on the start, so the OnStart function is empty (but it has to be redefined, see Menu.cs)

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : Menu {

	override protected void OnStart(){
	}
}
