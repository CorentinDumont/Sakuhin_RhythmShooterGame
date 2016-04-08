<<<<<<< HEAD
﻿// abstract class that defines the common characteristics of all the BulletWeapon objects (common at several levels)

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

abstract public class BulletLevel : MonoBehaviour {

	protected bool canGen = true;
	public GameObject bullet;

<<<<<<< HEAD
	abstract protected IEnumerator ShootBullet (); // the uncommon characteristic : time betweenn two shots and number and orientation of simultaneous shots

	protected void OnUpdate(){ // the common characteristic : shoot when it can
=======
	abstract protected IEnumerator ShootBullet ();

	protected void OnUpdate(){
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
		if (canGen) {
			canGen = false;
			StartCoroutine (ShootBullet ());
		}
	}
}
