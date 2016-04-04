using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed = 5.0f;
	public GameObject laser;
	public GameObject explosion;
	private bool canShoot = true;

	// Use this for initialization
	void Start () {
		// Add a vertical speed to the enemy
		this.GetComponent<Rigidbody>().velocity = new Vector3 (-1.0f, 0.0f, 0.0f) * speed;
	}

	IEnumerator Shoot(){
		yield return new WaitForSeconds (0.01f);
		if (Random.Range(0,21) == 0) {
			Instantiate (laser, transform.position + new Vector3(-1.0f,0.0f,0.0f), Quaternion.Euler(0,180,0));
		}
		canShoot = true;
	}

	// Update is called once per frame
	void Update () {
		float changingTrajectory = Random.Range (-20, 21);
		if (changingTrajectory == -1 || changingTrajectory == 1) {
			// Modify the vertical speed to the enemy
			this.GetComponent<Rigidbody> ().velocity = new Vector3 (-1.0f, 0.0f, changingTrajectory) * speed;
		}
		if (canShoot) {
			canShoot = false;
			StartCoroutine (Shoot ());
		}
	}

	public void Explode() {
		Instantiate (explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
