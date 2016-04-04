using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	public float speed = 3.0f;
	public GameObject explosion;

	// Use this for initialization
	void Start () {

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
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
