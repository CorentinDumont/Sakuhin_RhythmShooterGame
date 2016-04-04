using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuPlay : MenuChoice {

	override protected void Effect(){
		SceneManager.LoadScene ("Main");
	}
}
