using UnityEngine;
using System.Collections;

abstract public class LaserLevel : MonoBehaviour {

	protected bool canGen = true;
	public GameObject laser;

	abstract protected IEnumerator ShootLaser ();

	protected void OnUpdate(){
		if (canGen) {
			canGen = false;
			StartCoroutine (ShootLaser ());
		}
	}
}
