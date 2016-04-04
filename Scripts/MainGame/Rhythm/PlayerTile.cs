using UnityEngine;
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
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Bubble")) {
			bubbles.Enqueue(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Bubble")) {
			SendScore (0);
			StartCoroutine(DisplayAppreciation (0));
			bubbles.Dequeue();
		}
	}

	void SendScore(int score){
		handler.UpdateScore (score);
	}
}
