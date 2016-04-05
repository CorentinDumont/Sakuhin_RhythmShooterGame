// script attached to the PlayerTile, target of the rhythm game. Used for two functions (may be divided into two scripts afterward)
// function 1 : attached to the target of the rhythm game that is reached by the bubbles to inform the player about when he should press the "g" key
// see Bubble.cs
// function 2 : instantiate the UI Text object that display an appreciation about the precision of the player in the rhythm game
// (will probably be moved to an other object if the game uses several targets)

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTile : MonoBehaviour {

	public string key; // key to press when a bubble is on the target
	public GameObject rhythmEventsPanel; // the panel where the appreciations are displayed
	public GameObject rhythmBoard; // the object used to locate the rhythm game on the screen to place the previous panel correctly
	public Text[] appreciationsArray; // contains the different possible annotations

	private Queue bubbles; // contains the bubble that are currently over the target (there can be several at the same time)
	private Text currentAppreciation; // contains the appreciation that is currently displayed (used to destroy it afterward)
	//private int utilityForDestroy = 0;
	private bool waitingForDestroying = false; // used to handle the quick succession of appreciations (not totally functionnal)

	public GameEventsHandler handler; // the global object that handle events (update of combo, effects on shooter game...)

	// Use this for initialization
	void Start () {
		bubbles = new Queue ();
		this.GetComponent<Rigidbody>().angularVelocity = new Vector3 (0.0f, 20.0f, 0.0f); // makes the target rotate (style)

		Vector3 screenPositionRhythmBoard = Camera.main.WorldToScreenPoint(rhythmBoard.transform.position); // locate the rhythm game on the screen
		RectTransform eventsPanelTransform = rhythmEventsPanel.GetComponent<RectTransform> ();
		eventsPanelTransform.position = new Vector2 (screenPositionRhythmBoard.x - 200, screenPositionRhythmBoard.y); // place the panel of appreciations on the right place
	}
	
	// Update is called once per frame
	void Update () { // used to detect when the player press the key corresponding to the target
		if (Time.timeScale>0 && Input.GetKeyDown (key)) {
			if (bubbles.Count>0){
				GameObject bubble = (GameObject)bubbles.Dequeue(); // associate the press event with the first bubble that entered the target (and that is still over it)
				Vector3 distance = this.transform.position - bubble.transform.position;
				float floatDistance = Mathf.Sqrt (Mathf.Pow(distance.x,2)+Mathf.Pow(distance.y,2)+Mathf.Pow(distance.z,2));
				float maxDistance = this.GetComponent<SphereCollider> ().radius + bubble.GetComponent<SphereCollider> ().radius;
				float score = floatDistance / maxDistance; // calculate the precision from the distance between the bubble and the target
				if (score < 0.1) {
					SendScore (5); // Fantastic precision
					StartCoroutine(DisplayAppreciation (5));
				} else if (score < 0.3) {
					SendScore (4); // Great precision
					StartCoroutine(DisplayAppreciation (4));
				} else if (score < 0.5) {
					SendScore (3); // Good precision
					StartCoroutine(DisplayAppreciation (3));
				} else if (score < 0.8) {
					SendScore (2); // Almost precision
					StartCoroutine(DisplayAppreciation (2));
				} else {
					SendScore (1); // Bad precision
					StartCoroutine(DisplayAppreciation (1));
				}
				Destroy (bubble); // remove the physical dequeued bubble for the game
			}
		}
	}

	void OnTriggerEnter(Collider other) { // add the bubble to the queue
		if (other.gameObject.CompareTag ("Bubble")) {
			bubbles.Enqueue(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) { // occurs when the player has not press the key in time
		if (other.gameObject.CompareTag ("Bubble")) {
			SendScore (0); // Miss
			StartCoroutine(DisplayAppreciation (0)); // display an appreciation for 1 second
			bubbles.Dequeue();
		}
	}

	void SendScore(int score){ // send the score to the events handler that will update the combo,... see GameEventsHandler.cs
		handler.UpdateScore (score);
	}

	IEnumerator DisplayAppreciation(int appreciation){ // Display an appreciation in the panel
		//if (utilityForDestroy>0) {
		//	Destroy (currentAppreciation.gameObject);
		//}
		//utilityForDestroy++;
		if (waitingForDestroying) {
			Destroy (currentAppreciation.gameObject); // Remove the appreciation before writing a new one
			waitingForDestroying = false;
		}
		currentAppreciation = (Text)Instantiate (appreciationsArray [appreciation], rhythmEventsPanel.GetComponent<RectTransform> ().position, Quaternion.identity);
		currentAppreciation.transform.SetParent (rhythmEventsPanel.transform);
		currentAppreciation.transform.localScale = new Vector3 (1,1,1);
		//int buff = utilityForDestroy;
		waitingForDestroying = true;
		yield return new WaitForSeconds (1.0f);
		//if (buff==utilityForDestroy) {
		if (waitingForDestroying) {
			Destroy (currentAppreciation.gameObject); // Remove the appreciation after 1 second
			waitingForDestroying = false;
		}
		//}

	}
}
