// abstract class that defines the common characteristics of all the BulletWeapon objects (common at several levels)

using UnityEngine;
using System.Collections;

abstract public class BulletLevel : MonoBehaviour {

	protected bool canGen = true;
	public GameObject bullet;

	abstract protected IEnumerator ShootBullet (); // the uncommon characteristic : time betweenn two shots and number and orientation of simultaneous shots

	protected void OnUpdate(){ // the common characteristic : shoot when it can
		if (canGen) {
			canGen = false;
			StartCoroutine (ShootBullet ());
		}
	}
}
