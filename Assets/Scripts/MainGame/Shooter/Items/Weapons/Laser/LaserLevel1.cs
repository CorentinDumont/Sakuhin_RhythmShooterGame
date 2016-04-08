// defines the LaserWeaponLevel abstract class
// attached to the LaserWeaponLevel1 objects, defines the particularity of this weapon

using UnityEngine;
using System.Collections;

public class LaserLevel1 : LaserLevel {

	// Update is called once per frame
	void Update () {
		OnUpdate ();
	}

	override protected IEnumerator ShootLaser() // shoot 1 laser every 0.2 second
	{
		yield return new WaitForSeconds (0.2f);
		Instantiate (laser, transform.position, transform.rotation);
		canGen = true;
	}
}
