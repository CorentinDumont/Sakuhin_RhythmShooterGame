// defines the LaserWeaponLevel abstract class
// attached to the LaserWeaponLevel2 objects, defines the particularity of this weapon

using UnityEngine;
using System.Collections;

public class LaserLevel2 : LaserLevel {

	// Update is called once per frame
	void Update () {
		OnUpdate ();
	}

	override protected IEnumerator ShootLaser() // shoot 3 laser every 0.5 seconds
	{
		yield return new WaitForSeconds (0.2f);
		Instantiate (laser, transform.position + new Vector3(0.0f,0.0f,0.3f), transform.rotation);
		Instantiate (laser, transform.position + new Vector3(0.3f,0.0f,0.0f), transform.rotation);
		Instantiate (laser, transform.position + new Vector3(0.0f,0.0f,-0.3f), transform.rotation);
		canGen = true;
	}

}
