using UnityEngine;
using System.Collections;

public class PauseMenuWrapper : MonoBehaviour {
	
	private bool paused = false;
	public GameObject pauseMenuCanvas;
	public GameObject rythmBoard;

	void Update(){
		if (Input.GetKeyDown("p")) {
			TogglePause ();
		}
	}

	public void TogglePause(){
		if (paused) {
			pauseMenuCanvas.SetActive (false);
			paused = false;
			Time.timeScale = 1;
			rythmBoard.GetComponent<AudioSource> ().Play ();
		}
		else {
			pauseMenuCanvas.SetActive (true);
			paused = true;
			Time.timeScale = 0;
			rythmBoard.GetComponent<AudioSource> ().Pause ();
		}
	}
}
