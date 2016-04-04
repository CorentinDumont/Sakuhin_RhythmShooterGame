using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 5.0f;

	// Use this for initialization
	void Start () {
		Vector3 movement = new Vector3 (Mathf.Cos(transform.eulerAngles.y*Mathf.PI/180)*Mathf.Cos(transform.eulerAngles.z*Mathf.PI/180),Mathf.Sin(transform.eulerAngles.z*Mathf.PI/180),-Mathf.Sin(transform.eulerAngles.y*Mathf.PI/180)*Mathf.Cos(transform.eulerAngles.z*Mathf.PI/180));
		GetComponent<Rigidbody>().velocity = movement * speed;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			other.GetComponent<Enemy> ().Explode ();
		} else if (other.gameObject.CompareTag ("Asteroid")) {
			other.GetComponent<Asteroid> ().Explode ();
		}
	}

}
