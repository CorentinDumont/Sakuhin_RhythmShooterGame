// defines the behaviour of asteroids
// attached to every asteroid objects (to the prefab)

using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	public float speed = 3.0f;
	public GameObject explosion; // explosion animation prefab for asteroids

	// Use this for initialization
	void Start () {

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
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
