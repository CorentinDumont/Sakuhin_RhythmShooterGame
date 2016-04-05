// abstract class that defines the common characteristics of all the LaserWeapon objects (common at several levels)

using UnityEngine;
using System.Collections;

abstract public class LaserLevel : MonoBehaviour {

	protected bool canGen = true;
	public GameObject laser;

	abstract protected IEnumerator ShootLaser (); // the uncommon characteristic : time betweenn two shots and number and orientation of simultaneous shots

	protected void OnUpdate(){ // the common characteristic : shoot when it can
		if (canGen) {
			canGen = false;
			StartCoroutine (ShootLaser ());
		}
	}
}
