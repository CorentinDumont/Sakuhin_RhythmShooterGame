<<<<<<< HEAD
﻿// defines the LaserWeaponLevel abstract class
// attached to the LaserWeaponLevel0 objects, defines the particularity of this weapon

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

public class LaserLevel0 : LaserLevel {

	// Update is called once per frame
	void Update () {
		OnUpdate ();
	}

<<<<<<< HEAD
	override protected IEnumerator ShootLaser() // shoot 1 laser every 0.5 second
=======
	override protected IEnumerator ShootLaser()
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
	{
		yield return new WaitForSeconds (0.5f);
		Instantiate (laser, transform.position, transform.rotation);
		canGen = true;
	}
}
