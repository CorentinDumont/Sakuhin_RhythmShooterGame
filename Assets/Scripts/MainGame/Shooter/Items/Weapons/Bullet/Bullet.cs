<<<<<<< HEAD
﻿// attached to the particle used in the Bullet weapons (little sphere)
// defines the behaviour of the bullets particles

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 5.0f;

	// Use this for initialization
<<<<<<< HEAD
	void Start () { // defines movement of the bullets, go straight with the specified speed
=======
	void Start () {
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
		Vector3 movement = new Vector3 (Mathf.Cos(transform.eulerAngles.y*Mathf.PI/180)*Mathf.Cos(transform.eulerAngles.z*Mathf.PI/180),Mathf.Sin(transform.eulerAngles.z*Mathf.PI/180),-Mathf.Sin(transform.eulerAngles.y*Mathf.PI/180)*Mathf.Cos(transform.eulerAngles.z*Mathf.PI/180));
		GetComponent<Rigidbody>().velocity = movement * speed;
	}

<<<<<<< HEAD
	void OnTriggerEnter(Collider other) { // defines the effects of collisions
		if (other.gameObject.CompareTag ("Enemy")) {
			other.GetComponent<Enemy> ().Explode (); // destroys colliding enemies (ships)
		} else if (other.gameObject.CompareTag ("Asteroid")) {
			other.GetComponent<Asteroid> ().Explode (); // destroys colliding asteroids
=======
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			other.GetComponent<Enemy> ().Explode ();
		} else if (other.gameObject.CompareTag ("Asteroid")) {
			other.GetComponent<Asteroid> ().Explode ();
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
		}
	}

}
