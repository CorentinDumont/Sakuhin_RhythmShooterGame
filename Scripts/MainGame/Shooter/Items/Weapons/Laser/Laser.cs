using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float speed = 7.0f;

	// Use this for initialization
	void Start () {
		Vector3 movement = new Vector3 (Mathf.Cos(transform.eulerAngles.y*Mathf.PI/180)*Mathf.Cos(transform.eulerAngles.z*Mathf.PI/180),Mathf.Sin(transform.eulerAngles.z*Mathf.PI/180),-Mathf.Sin(transform.eulerAngles.y*Mathf.PI/180)*Mathf.Cos(transform.eulerAngles.z*Mathf.PI/180));
		GetComponent<Rigidbody>().velocity = movement * speed;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player") && this.gameObject.CompareTag("LaserEnemy")) {
			other.GetComponent<PlayerShip> ().Explode ();
		} else if (other.gameObject.CompareTag ("Enemy") && this.gameObject.CompareTag("Laser")) {
			other.GetComponent<Enemy> ().Explode ();
		} else if (other.gameObject.CompareTag ("Asteroid") && this.gameObject.CompareTag("Laser")) {
			other.GetComponent<Asteroid> ().Explode ();
		}
	}
}
