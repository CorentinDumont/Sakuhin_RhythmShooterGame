<<<<<<< HEAD
﻿// abstract class that defines the common characteristics of all the LaserWeapon objects (common at several levels)

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

abstract public class LaserLevel : MonoBehaviour {

	protected bool canGen = true;
	public GameObject laser;

<<<<<<< HEAD
	abstract protected IEnumerator ShootLaser (); // the uncommon characteristic : time betweenn two shots and number and orientation of simultaneous shots

	protected void OnUpdate(){ // the common characteristic : shoot when it can
=======
	abstract protected IEnumerator ShootLaser ();

	protected void OnUpdate(){
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
		if (canGen) {
			canGen = false;
			StartCoroutine (ShootLaser ());
		}
	}
}
