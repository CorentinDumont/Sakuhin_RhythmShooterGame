// defines the behaviour of enemies (ships)
// attached to every asteroid objects (to the prefab)

using UnityEngine;
using System.Collections;

abstract public class Enemy : BossOrEnemy {

	override public void TakeDamages(int damages){
		hp -= damages;
		if (hp <= 0) {
			Explode ();
		}
	}

	void OnTriggerEnter(Collider other) { // effects of collision with other objects
		if (other.GetComponent<PlayerShip> () != null || other.GetComponent<Enemy> () != null) {
			Explode (); // destroy itself
		}
	}
}
