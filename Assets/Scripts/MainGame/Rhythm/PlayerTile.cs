<<<<<<< HEAD
﻿// script attached to the PlayerTiles, targets of the rhythm game.

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
=======
﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerTile : MonoBehaviour {

	public string key;
	public GameObject rhythmEventsPanel;
	public GameObject rhythmBoard;
	public Text[] appreciationsArray;

	private Queue bubbles;
	private Text currentAppreciation;
	//private int utilityForDestroy = 0;
	private bool waitingForDestroying = false;

	public GameEventsHandler handler;

	// Use this for initialization
	void Start () {
		bubbles = new Queue ();
		this.GetComponent<Rigidbody>().angularVelocity = new Vector3 (0.0f, 20.0f, 0.0f);

		Vector3 screenPositionRhythmBoard = Camera.main.WorldToScreenPoint(rhythmBoard.transform.position);
		RectTransform eventsPanelTransform = rhythmEventsPanel.GetComponent<RectTransform> ();
		eventsPanelTransform.position = new Vector2 (screenPositionRhythmBoard.x - 200, screenPositionRhythmBoard.y);
	}

	IEnumerator DisplayAppreciation(int appreciation){
		//if (utilityForDestroy>0) {
		//	Destroy (currentAppreciation.gameObject);
		//}
		//utilityForDestroy++;
		if (waitingForDestroying) {
			Destroy (currentAppreciation.gameObject);
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
			Destroy (currentAppreciation.gameObject);
			waitingForDestroying = false;
		}
		//}

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale>0 && Input.GetKeyDown (key)) {
			if (bubbles.Count>0){
				GameObject bubble = (GameObject)bubbles.Dequeue();
				Vector3 distance = this.transform.position - bubble.transform.position;
				float floatDistance = Mathf.Sqrt (Mathf.Pow(distance.x,2)+Mathf.Pow(distance.y,2)+Mathf.Pow(distance.z,2));
				float maxDistance = this.GetComponent<SphereCollider> ().radius + bubble.GetComponent<SphereCollider> ().radius;
				float score = floatDistance / maxDistance;
				if (score < 0.1) {
					SendScore (5);
					StartCoroutine(DisplayAppreciation (5));
				} else if (score < 0.3) {
					SendScore (4);
					StartCoroutine(DisplayAppreciation (4));
				} else if (score < 0.5) {
					SendScore (3);
					StartCoroutine(DisplayAppreciation (3));
				} else if (score < 0.8) {
					SendScore (2);
					StartCoroutine(DisplayAppreciation (2));
				} else {
					SendScore (1);
					StartCoroutine(DisplayAppreciation (1));
				}
				Destroy (bubble);
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
			}
		}
	}

<<<<<<< HEAD
	void OnTriggerEnter(Collider other) { // add the bubble to the queue
		if (other.gameObject.CompareTag ("Bubble")) {
			bubbles.Enqueue(other.gameObject.GetComponent<Bubble>());
		}
	}

	void OnTriggerExit(Collider other) { // occurs when the player has not press the key in time
		if (other.gameObject.CompareTag ("Bubble")) {
			SendScore (0); // Miss
=======
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Bubble")) {
			bubbles.Enqueue(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Bubble")) {
			SendScore (0);
			StartCoroutine(DisplayAppreciation (0));
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
			bubbles.Dequeue();
		}
	}

<<<<<<< HEAD
	void SendScore(int score){ // send the score to the events handler that will update the combo,... see GameEventsHandler.cs
=======
	void SendScore(int score){
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
		handler.UpdateScore (score);
	}
}
