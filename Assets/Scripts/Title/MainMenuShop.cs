using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuShop : MenuChoice {

	override protected void Effect(){
		SceneManager.LoadScene ("Shop");
	}
}
