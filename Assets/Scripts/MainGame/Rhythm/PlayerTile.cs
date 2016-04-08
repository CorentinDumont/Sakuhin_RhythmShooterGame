// script attached to the PlayerTiles, targets of the rhythm game.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerTile : MonoBehaviour {

	public string key; // key to press when a bubble is on the target

	private Queue<Bubble> bubbles; // contains the bubble that are currently over the target (there can be several at the same time)

	public GameEventsHandler handler; // the global object that handle events (update of combo, effects on shooter game...)

	// Use this for initialization
	void Start () {
		bubbles = new Queue<Bubble> ();
		this.GetComponent<Rigidbody>().angularVelocity = new Vector3 (0.0f, 20.0f, 0.0f); // makes the target rotate (style)
	}
	
	// Update is called once per frame
	void Update () { // used to detect when the player press the key corresponding to the target
		if (Time.timeScale>0 && Input.GetKeyDown (key)) {
			if (bubbles.Count>0){
				Bubble bubble = bubbles.Dequeue(); // associate the press event with the first bubble that entered the target (and that is still over it)
				//Vector3 distance = this.transform.position - bubble.transform.position;
				//float floatDistance = Mathf.Sqrt (Mathf.Pow(distance.x,2)+Mathf.Pow(distance.y,2)+Mathf.Pow(distance.z,2));
				//float maxDistance = this.GetComponent<SphereCollider> ().radius + bubble.GetComponent<SphereCollider> ().radius;
				//float score = floatDistance / maxDistance; // calculate the precision from the distance between the bubble and the target
				float score = Mathf.Abs(Time.realtimeSinceStartup - bubble.GetBeatTime());
				if (score < 0.02) {
					SendScore (5); // Fantastic precision
				} else if (score < 0.07) {
					SendScore (4); // Great precision
				} else if (score < 0.12) {
					SendScore (3); // Good precision
				} else if (score < 0.2) {
					SendScore (2); // Almost precision
				} else if (score < 0.5) {
					SendScore (1); // Bad precision
				} else {
					SendScore (0); // Miss
				}
				Destroy (bubble.gameObject); // remove the physical dequeued bubble for the game
			}
		}
	}

	void OnTriggerEnter(Collider other) { // add the bubble to the queue
		if (other.gameObject.CompareTag ("Bubble")) {
			bubbles.Enqueue(other.gameObject.GetComponent<Bubble>());
		}
	}

	void OnTriggerExit(Collider other) { // occurs when the player has not press the key in time
		if (other.gameObject.CompareTag ("Bubble")) {
			SendScore (0); // Miss
			bubbles.Dequeue();
		}
	}

	void SendScore(int score){ // send the score to the events handler that will update the combo,... see GameEventsHandler.cs
		handler.UpdateScore (score);
	}
}
