using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenuMainMenu : MenuChoice {

	override protected void Effect(){
		SceneManager.LoadScene ("Title");
	}
}
