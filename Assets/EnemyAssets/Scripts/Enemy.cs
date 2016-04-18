// defines the behaviour of enemies (ships)
// attached to every asteroid objects (to the prefab)

using UnityEngine;
using System.Collections;

abstract public class Enemy : MonoBehaviour {

	public Vector3 vectorForward = Vector3.forward;
	public Vector3 vectorUp = Vector3.up;
	public float speed;
	public int hp;
	public int scoreUp;
	public GameObject explosion; // explosion animation prefab for enemies

	protected GameObject weapon;
	protected GameObject weaponTarget;

	protected GameObject directionTarget;

	// Use this for initialization
	void Start () {
		if (GetComponentInChildren<EnemyLaserWeapon> () != null) {
			weapon = GetComponentInChildren<EnemyLaserWeapon> ().transform.parent.gameObject;
			weaponTarget = GameValuesContainer.container.shooterHandler.playerShip.gameObject;
		}

		directionTarget = GameValuesContainer.container.shooterHandler.enemyDirectionTarget;

		OnStart ();
	}

	abstract protected void OnStart ();

	// Update is called once per frame
	void Update () {
		if (weapon != null) {
			weapon.transform.LookAt (weaponTarget.GetComponent<Collider> ().bounds.center, vectorUp);
		}

		OnUpdate ();
	}

	abstract protected void OnUpdate ();

	public void TakeDamages(int damages){
		hp -= damages;
		if (hp <= 0) {
			Explode ();
		}
	}

	public void Explode() { // Destroys itself and makes the explosion animation
		GameObject particle = (GameObject)Instantiate (explosion, transform.position, Quaternion.identity);
		particle.transform.SetParent (GameValuesContainer.container.particlesContainer.transform);
		GameValuesContainer.container.shooterHandler.IncreaseScore (scoreUp);
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other) { // effects of collision with other objects
		if (other.GetComponent<PlayerShip> () != null) {
			other.GetComponent<PlayerShip> ().Explode (); // destroy colliding player
			Explode (); // destroy itself
		}
		else if (other.GetComponent<Enemy> () != null) {
			Explode(); // destroy itself
		}
	}
}
