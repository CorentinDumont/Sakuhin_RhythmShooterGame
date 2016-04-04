using UnityEngine;
using System.Collections;

public class LaserLevel1 : LaserLevel {

	// Update is called once per frame
	void Update () {
		OnUpdate ();
	}

	override protected IEnumerator ShootLaser()
	{
		yield return new WaitForSeconds (0.2f);
		Instantiate (laser, transform.position, transform.rotation);
		canGen = true;
	}
}
