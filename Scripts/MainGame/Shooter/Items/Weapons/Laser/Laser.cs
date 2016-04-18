// attached to the particle used in the Laser weapons (little ray)
// defines the behaviour of the laser particles

using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float speed = 15f;
	public int damages = 1;

	// Use this for initialization
	void Start () { // defines movement of the bullets, go straight with the specified speed
		Vector3 movement = new Vector3 (Mathf.Cos(transform.eulerAngles.y*Mathf.PI/180)*Mathf.Cos(transform.eulerAngles.z*Mathf.PI/180),Mathf.Sin(transform.eulerAngles.z*Mathf.PI/180),-Mathf.Sin(transform.eulerAngles.y*Mathf.PI/180)*Mathf.Cos(transform.eulerAngles.z*Mathf.PI/180));
		GetComponent<Rigidbody>().velocity = movement * speed;
	}

	void OnTriggerEnter(Collider other) { // defines the effects of collisions
		if (other.GetComponent<Enemy> () != null) {
			other.GetComponent<Enemy> ().TakeDamages(damages); // destroys colliding enemies (ships)
			Destroy(gameObject);
		}
	}
}
