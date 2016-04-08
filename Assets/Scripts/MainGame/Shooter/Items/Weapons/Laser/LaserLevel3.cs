﻿// defines the LaserWeaponLevel abstract class
// attached to the LaserWeaponLevel3 objects, defines the particularity of this weapon

using UnityEngine;
using System.Collections;

public class LaserLevel3 : LaserLevel {

	// Update is called once per frame
	void Update () {
		OnUpdate ();
	}

	override protected IEnumerator ShootLaser() // shoot 5 laser every 0.5 seconds
	{
		yield return new WaitForSeconds (0.2f);
		Instantiate (laser, transform.position + new Vector3(0.0f,0.0f,0.3f), transform.rotation);
		Instantiate (laser, transform.position + new Vector3(0.3f,0.0f,0.0f), transform.rotation);
		Instantiate (laser, transform.position + new Vector3(0.0f,0.0f,-0.3f), transform.rotation);
		Instantiate (laser, transform.position + new Vector3(-0.2f,0.0f,0.6f), transform.rotation * Quaternion.Euler(0.0f,-45,0.0f));
		Instantiate (laser, transform.position + new Vector3(-0.2f,0.0f,-0.6f), transform.rotation * Quaternion.Euler(0.0f,45,0.0f));
		canGen = true;
	}

}
