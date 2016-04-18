using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

	private Animator animator;

	void Awake(){
		animator = GetComponent<Animator>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("i")) {
			animator.SetTrigger("Hit");
		}
		if (Input.GetKeyDown("u")) {
			animator.SetBool ("Attack", true);
		}
		if (Input.GetKeyDown("y")) {
			animator.SetBool ("Attack", false);
		}
	}
}
