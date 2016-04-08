//Used to display an appreciation about the precision of the player in the rhythm game

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Appreciations : MonoBehaviour {

	public GameObject rhythmEventsPanel; // the panel where the appreciations are displayed
	public Text[] appreciationsArray; // contains the different possible annotations

	private Text currentAppreciation;
	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
	}
	
	public void DisplayAppreciation(int appreciation){ // Displays an appreciation in the panel
		if (coroutine != null) {
			StopCoroutine (coroutine);
		}
		coroutine = CoroutineDisplayAppreciation (appreciation);
		StartCoroutine(coroutine);
	}

	IEnumerator CoroutineDisplayAppreciation(int appreciation){
		if (currentAppreciation) {
			Destroy (currentAppreciation.gameObject); // Remove the appreciation to write the following
		}
		Quaternion rotation = Quaternion.identity;
		rotation.z += Random.Range(-0.25f,0.25f);
		Vector3 position = rhythmEventsPanel.GetComponent<RectTransform> ().position;
		position.x += Random.Range (-20,20);
		position.y += Random.Range (-20,20);
		currentAppreciation = (Text)Instantiate (appreciationsArray [appreciation],position ,rotation);
		currentAppreciation.transform.SetParent (rhythmEventsPanel.transform);
		currentAppreciation.transform.localScale = new Vector3 (1,1,1);

		yield return new WaitForSeconds (1.0f);
		Destroy (currentAppreciation.gameObject); // Remove the appreciation after 1 second
		currentAppreciation = null;
		coroutine = null;

	}
}
