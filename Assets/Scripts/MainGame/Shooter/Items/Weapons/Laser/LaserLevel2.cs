using UnityEngine;
using System.Collections;

public class LaserLevel2 : LaserLevel {

	// Update is called once per frame
	void Update () {
		OnUpdate ();
	}

	override protected IEnumerator ShootLaser()
	{
		yield return new WaitForSeconds (0.2f);
		Instantiate (laser, transform.position + new Vector3(0.0f,0.0f,0.3f), transform.rotation);
		Instantiate (laser, transform.position + new Vector3(0.3f,0.0f,0.0f), transform.rotation);
		Instantiate (laser, transform.position + new Vector3(0.0f,0.0f,-0.3f), transform.rotation);
		canGen = true;
	}

}
