// Class attached to the object of the game that contains the canvas for the pause menu in the main scene
// is used to enable and disable the pause menu by activating and disactivating the canvas

// the pause is done by stop the time with Time.timeScale
// Attention : is doesn't work for audioSources, so they have to be stopped manually

using UnityEngine;
using System.Collections;

public class PauseMenuWrapper : MonoBehaviour {
	
	private bool paused = false;
	public GameObject pauseMenuCanvas; // canvas containg the objects of the pause menu
	public SpawnSpot spawnSpot; // the object on which the audioSource of the main scene is attached

	void Start(){
		spawnSpot.Play();
	}

	void Update(){
		if (Input.GetKeyDown("p")) {
			TogglePause ();
		}
		if (Input.GetKeyDown("o")) {
			spawnSpot.Play();
		}
		if (Input.GetKeyDown("i")) {
			spawnSpot.IncreaseDifficulty();
		}
		if (Input.GetKeyDown("u")) {
			spawnSpot.DecreaseDifficulty();
		}
	}

	public void TogglePause(){
		if (paused) {
			pauseMenuCanvas.SetActive (false);
			paused = false;
			Time.timeScale = 1;	// unpause the time
			spawnSpot.Play(); // unpause the audio source
		}
		else {
			pauseMenuCanvas.SetActive (true);
			paused = true;
			Time.timeScale = 0; // pause the time
			spawnSpot.Pause(); // pause the audio source
		}
	}
}
