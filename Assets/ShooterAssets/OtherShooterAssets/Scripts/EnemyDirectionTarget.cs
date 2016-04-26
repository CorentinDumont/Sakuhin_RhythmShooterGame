using UnityEngine;
using System.Collections;

public class EnemyDirectionTarget : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Destroy (other.gameObject);
	}
}
