using UnityEngine;
using System.Collections;

public class Boss01 : MonoBehaviour {

	public Vector3 vectorForward = Vector3.forward;
	public Vector3 vectorUp = Vector3.up;
	public float speed;
	public int hp;
	public int scoreUp;

	private Boss01SingleWeapon[] singleWeapons;
	private Boss01ZoneWeapon zoneWeapon;
	private GameObject weaponTarget;
	private GameObject directionTarget;

	private IEnumerator coroutinePosition;
	private IEnumerator coroutineFollow;
	private Animator animator;

	// Use this for initialization
	void Start () {
		singleWeapons = GetComponentsInChildren<Boss01SingleWeapon> ();
		zoneWeapon = GetComponentInChildren<Boss01ZoneWeapon> ();
		weaponTarget = GameValuesContainer.container.shooterHandler.playerShip.gameObject;
		directionTarget = GameValuesContainer.container.shooterHandler.bossDirectionTarget;

		animator = GetComponent<Animator> ();

		coroutinePosition = GoToPosition();
		StartCoroutine (coroutinePosition);
	}

	void Update () {
		foreach (Boss01SingleWeapon weapon in singleWeapons) {
			weapon.transform.LookAt (weaponTarget.GetComponent<Collider>().bounds.center, vectorUp);
		}
		zoneWeapon.transform.LookAt (weaponTarget.GetComponent<Collider>().bounds.center, vectorUp);

		if (Input.GetKeyDown ("left")) {
		//	animator.SetTrigger("Form1");
		}
		else if (Input.GetKeyDown ("up")) {
		//	animator.SetTrigger("Form2");
		}
		else if (Input.GetKeyDown ("right")) {
		//	animator.SetTrigger("Form3");
		}
		if (coroutinePosition == null) {
			if (coroutineFollow != null) {
				StopCoroutine (coroutineFollow);
			}
			coroutineFollow = Follow ();
			StartCoroutine (coroutineFollow);
			animator.SetTrigger("Form1");
		}
	}

	public void WeakCircleShoot(){
		zoneWeapon.WeakCircleShoot ();
	}

	public void WeakSlalomShoot(){
		zoneWeapon.WeakSlalomShoot ();
	}

	public void StrongCircleShoot(){
		zoneWeapon.StrongCircleShoot ();
	}

	public void StrongSlalomShoot(){
		zoneWeapon.StrongSlalomShoot ();
	}

	public void WeakShoot(){
		foreach (Boss01SingleWeapon weapon in singleWeapons) {
			weapon.WeakShoot ();
		}
	}

	public void MediumShoot(){
		foreach (Boss01SingleWeapon weapon in singleWeapons) {
			weapon.MediumShoot ();
		}
	}

	public void StrongShoot(){
		foreach (Boss01SingleWeapon weapon in singleWeapons) {
			weapon.StrongShoot ();
		}
	}

	IEnumerator GoToPosition(){
		this.transform.LookAt (directionTarget.transform);
		GetComponent<Rigidbody> ().velocity = Utility.GetDirection (this.transform, vectorForward) * speed;
		float distance = (directionTarget.transform.position - this.transform.position).magnitude;
		float minDistance = distance;
		while (distance <= minDistance) {
			yield return null;
			distance = (directionTarget.transform.position - this.transform.position).magnitude;
			minDistance = Mathf.Min (minDistance,distance);
		}
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		coroutinePosition = null;
	}

	IEnumerator Follow(){
		Vector3 directionOrigin = Utility.GetDirection(this.transform,vectorForward);
		Vector3 directionFinal = this.transform.position - weaponTarget.transform.position;
		directionFinal.Normalize ();
		float degree = 0;
		while (degree<1) {
			if (Time.timeScale > 0) {
				degree = Mathf.Min (1, degree + 0.05f);
				this.transform.LookAt (Utility.DirectionBetween (directionOrigin, directionFinal, degree) + this.transform.position, vectorUp);
			}
			yield return null;
		}
		coroutineFollow = null;
	}
}
