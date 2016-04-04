using UnityEngine;
using System.Collections;

abstract public class BulletLevel : MonoBehaviour {

	protected bool canGen = true;
	public GameObject bullet;

	abstract protected IEnumerator ShootBullet ();

	protected void OnUpdate(){
		if (canGen) {
			canGen = false;
			StartCoroutine (ShootBullet ());
		}
	}
}
