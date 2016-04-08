<<<<<<< HEAD
﻿// defines the behaviour of asteroids
// attached to every asteroid objects (to the prefab)

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

public class Asteroid : MonoBehaviour {

	public float speed = 3.0f;
<<<<<<< HEAD
	public GameObject explosion; // explosion animation prefab for asteroids
=======
	public GameObject explosion;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479

	// Use this for initialization
	void Start () {

<<<<<<< HEAD
		// Add a vertical speed to the asteroid
		this.GetComponent<Rigidbody> ().velocity = new Vector3 (-1.0f, 0.0f, 0.0f) * speed;
		// Make the asteroid rotate on itself
		this.GetComponent<Rigidbody> ().angularVelocity = new Vector3 (Random.Range (-200, 200), Random.Range (-200, 200), Random.Range (-200, 200));
	
	}

	void OnTriggerEnter(Collider other) { // effects of collision with other objects
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<PlayerShip> ().Explode (); // destroy colliding player
		} else if (other.gameObject.CompareTag ("Enemy")) {
			other.GetComponent<Enemy>().Explode(); // destroy colliding enemies (ships)
		} else if (other.gameObject.CompareTag ("Asteroid")) {
			this.Explode (); // destroy itself if collides with an other asteroid
		}
	}

	public void Explode() { // destroys itself and makes the explosion animation
=======
		// Add a vertical speed to the enemy
		this.GetComponent<Rigidbody>().velocity = new Vector3 (-1.0f, 0.0f, 0.0f) * speed;
		// Make the enemy rotate on itself
		this.GetComponent<Rigidbody>().angularVelocity = new Vector3 (Random.Range(-200, 200), Random.Range(-200, 200), Random.Range(-200, 200));
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<PlayerShip> ().Explode ();
		} else if (other.gameObject.CompareTag ("Enemy")) {
			other.GetComponent<Enemy>().Explode();
		} else if (other.gameObject.CompareTag ("Asteroid")) {
			this.Explode ();
		}
	}

	public void Explode() {
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
