<<<<<<< HEAD
﻿// Class attached to the object of the game that contains the canvas for the pause menu in the main scene
// is used to enable and disable the pause menu by activating and disactivating the canvas

// the pause is done by stop the time with Time.timeScale
// Attention : is doesn't work for audioSources, so they have to be stopped manually

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

public class PauseMenuWrapper : MonoBehaviour {
	
	private bool paused = false;
<<<<<<< HEAD
	public GameObject pauseMenuCanvas; // canvas containg the objects of the pause menu
	public SpawnSpot spawnSpot; // the object on which the audioSource of the main scene is attached

	void Start(){
		spawnSpot.Play();
	}
=======
	public GameObject pauseMenuCanvas;
	public GameObject rythmBoard;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479

	void Update(){
		if (Input.GetKeyDown("p")) {
			TogglePause ();
		}
<<<<<<< HEAD
		if (Input.GetKeyDown("o")) {
			spawnSpot.Play();
		}
		if (Input.GetKeyDown("i")) {
			spawnSpot.IncreaseDifficulty();
		}
		if (Input.GetKeyDown("u")) {
			spawnSpot.DecreaseDifficulty();
		}
=======
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
	}

	public void TogglePause(){
		if (paused) {
			pauseMenuCanvas.SetActive (false);
			paused = false;
<<<<<<< HEAD
			Time.timeScale = 1;	// unpause the time
			spawnSpot.Play(); // unpause the audio source
=======
			Time.timeScale = 1;
			rythmBoard.GetComponent<AudioSource> ().Play ();
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
		}
		else {
			pauseMenuCanvas.SetActive (true);
			paused = true;
<<<<<<< HEAD
			Time.timeScale = 0; // pause the time
			spawnSpot.Pause(); // pause the audio source
=======
			Time.timeScale = 0;
			rythmBoard.GetComponent<AudioSource> ().Pause ();
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
		}
	}
}
