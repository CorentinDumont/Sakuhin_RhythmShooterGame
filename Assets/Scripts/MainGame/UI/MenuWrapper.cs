// Class attached to the object of the game that contains the canvas for the pause menu in the main scene
// is used to enable and disable the pause menu by activating and disactivating the canvas

// the pause is done by stop the time with Time.timeScale
// Attention : is doesn't work for audioSources, so they have to be stopped manually

using UnityEngine;
using System.Collections;

public class MenuWrapper : MonoBehaviour {

	public GameObject eventsLayer;
	public Menu pauseMenuCanvas; // canvas containg the objects of the pause menu
	public Menu gameOverMenuCanvas; // canvas containg the objects of the game over menu
	public ResultsCanvas resultsCanvas; // canvas containg the results panel

	private bool paused = false;
	private bool gameOver = false;
	private bool displayingResults = false;

	void Awake(){
		if (GameValuesContainer.container == null) {
			GameValuesContainer.container = new GameValuesContainer ();
		}
		GameValuesContainer.container.menuWrapper = this;
	}

	void Update(){
		if (Input.GetKeyDown("p")) {
			TogglePause ();
		}
		if (Input.GetKeyDown("o")) {
			DisplayResults ();
		}
		if (Input.GetKeyDown("i")) {
			GameValuesContainer.container.rhythmHandler.spawnSpot.IncreaseDifficulty();
		}
		if (Input.GetKeyDown("u")) {
			GameValuesContainer.container.rhythmHandler.spawnSpot.DecreaseDifficulty();
		}
	}

	public void DisplayResults(){
		displayingResults = true;
		resultsCanvas.gameObject.SetActive (displayingResults);
		eventsLayer.SetActive (!displayingResults);
		if (displayingResults) {
			HideMenu (pauseMenuCanvas);
			HideMenu (gameOverMenuCanvas);
		}
		resultsCanvas.StartDisplaying ();
	}

	public void ToggleGameOver(){
		if (!displayingResults) {
			if (gameOver) {
				gameOver = HideMenu (gameOverMenuCanvas);
				Unpause ();
			} else {
				if (paused) {
					paused = HideMenu (pauseMenuCanvas);
				}
				gameOver = DisplayMenu (gameOverMenuCanvas);
				Pause ();
			}
		}
	}

	public void TogglePause(){
		if (!gameOver && !displayingResults) {
			if (paused) {
				paused = HideMenu (pauseMenuCanvas);
				Unpause ();
			}
			else {
				paused = DisplayMenu (pauseMenuCanvas);
				Pause ();
			}
		}
	}

	void Pause(){
		Time.timeScale = 0; // pause the time
		GameValuesContainer.container.rhythmHandler.spawnSpot.Pause(); // pause the audio source
	}

	void Unpause(){
		Time.timeScale = 1;	// unpause the time
		GameValuesContainer.container.rhythmHandler.spawnSpot.Play(); // unpause the audio source
	}

	bool DisplayMenu(Menu menu){
		menu.gameObject.SetActive (true);
		return true;
	}

	bool HideMenu(Menu menu){
		menu.gameObject.SetActive (false);
		return false;
	}
}
