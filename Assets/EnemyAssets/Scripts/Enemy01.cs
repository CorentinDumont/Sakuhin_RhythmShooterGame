// defines the behaviour of enemies (ships)
// attached to every asteroid objects (to the prefab)

using UnityEngine;
using System.Collections;

public class Enemy01 : Enemy {

	private IEnumerator coroutine;

	override protected void OnStart (){
		Vector3 direction = Utility.RandomPointOf (directionTarget.GetComponent<Renderer>());
		this.transform.LookAt (direction, vectorUp);
		if (GetComponentInChildren<Animator> () != null) {
			GetComponentInChildren<Animator> ().SetTrigger ("Shoot");
		}
	}

	override protected void OnUpdate (){
		if (coroutine == null) {
			coroutine = CoroutineMove ();
			StartCoroutine (coroutine);
		}
	}

	IEnumerator CoroutineMove(){
		Vector3 directionOrigin = Utility.GetDirection(this.transform,vectorForward);
		Vector3 directionFinal = Utility.RandomPointOf (directionTarget.GetComponent<Renderer>()) - this.transform.position;
		directionFinal.Normalize ();
		float degree = 0;
		while (degree<1) {
			if (Time.timeScale > 0) {
				degree = Mathf.Min (1, degree + 0.05f);
				this.transform.LookAt (Utility.DirectionBetween (directionOrigin, directionFinal, degree) + this.transform.position, vectorUp);
				GetComponent<Rigidbody> ().velocity = Utility.GetDirection (this.transform, vectorForward) * speed;
			}
			yield return null;
		}
		yield return new WaitForSeconds (Random.Range(0,1));
		coroutine = null;
	}

	public void Shoot(){
		if (GetComponentInChildren<EnemyLaserWeapon> () != null) {
			GetComponentInChildren<EnemyLaserWeapon> ().Shoot ();
		}
	}


}
