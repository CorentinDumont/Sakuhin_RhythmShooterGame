using UnityEngine;
using System.Collections;

public class GameBorder : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Destroy (other.gameObject);
	}
}
