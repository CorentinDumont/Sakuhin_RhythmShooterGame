using UnityEngine;
using System.Collections;

public class BulletLevel1 : BulletLevel {

	// Update is called once per frame
	void Update () {
		OnUpdate ();
	}

	override protected IEnumerator ShootBullet()
	{
		yield return new WaitForSeconds (0.2f);
		Instantiate (bullet, transform.position, transform.rotation);
		Instantiate (bullet, transform.position + new Vector3(-0.2f,0.0f,0.3f), transform.rotation * Quaternion.Euler(0.0f,-15,0.0f));
		Instantiate (bullet, transform.position + new Vector3(-0.2f,0.0f,-0.3f), transform.rotation * Quaternion.Euler(0.0f,15,0.0f));
		canGen = true;
	}
}
