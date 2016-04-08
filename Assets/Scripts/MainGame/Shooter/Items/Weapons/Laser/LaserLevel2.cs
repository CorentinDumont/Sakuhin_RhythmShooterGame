<<<<<<< HEAD
﻿// defines the LaserWeaponLevel abstract class
// attached to the LaserWeaponLevel2 objects, defines the particularity of this weapon

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

public class LaserLevel2 : LaserLevel {

	// Update is called once per frame
	void Update () {
		OnUpdate ();
	}

<<<<<<< HEAD
	override protected IEnumerator ShootLaser() // shoot 3 laser every 0.5 seconds
=======
	override protected IEnumerator ShootLaser()
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
	{
		yield return new WaitForSeconds (0.2f);
		Instantiate (laser, transform.position + new Vector3(0.0f,0.0f,0.3f), transform.rotation);
		Instantiate (laser, transform.position + new Vector3(0.3f,0.0f,0.0f), transform.rotation);
		Instantiate (laser, transform.position + new Vector3(0.0f,0.0f,-0.3f), transform.rotation);
		canGen = true;
	}

}
