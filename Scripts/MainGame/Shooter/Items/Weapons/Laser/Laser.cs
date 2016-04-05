// attached to the particle used in the Laser weapons (little ray)
// defines the behaviour of the laser particles

using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public float speed = 7.0f;

	// Use this for initialization
	void Start () { // defines movement of the bullets, go straight with the specified speed
		Vector3 movement = new Vector3 (Mathf.Cos(transform.eulerAngles.y*Mathf.PI/180)*Mathf.Cos(transform.eulerAngles.z*Mathf.PI/180),Mathf.Sin(transform.eulerAngles.z*Mathf.PI/180),-Mathf.Sin(transform.eulerAngles.y*Mathf.PI/180)*Mathf.Cos(transform.eulerAngles.z*Mathf.PI/180));
		GetComponent<Rigidbody>().velocity = movement * speed;
	}

	void OnTriggerEnter(Collider other) { // defines the effects of collisions
		if (other.gameObject.CompareTag ("Player") && this.gameObject.CompareTag("LaserEnemy")) {
			other.GetComponent<PlayerShip> ().Explode (); // destroys colliding player if comes from enemies
		} else if (other.gameObject.CompareTag ("Enemy") && this.gameObject.CompareTag("Laser")) {
			other.GetComponent<Enemy> ().Explode (); // destroys colliding enemies (ships) if comes from player
		} else if (other.gameObject.CompareTag ("Asteroid") && this.gameObject.CompareTag("Laser")) {
			other.GetComponent<Asteroid> ().Explode (); // destroys colliding asteroids if comes from player
		}
	}
}
