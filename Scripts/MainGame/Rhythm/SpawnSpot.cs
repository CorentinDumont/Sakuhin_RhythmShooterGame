using UnityEngine;
using System.Collections;

public class SpawnSpot : MonoBehaviour {

	public GameObject bubble;
	public GameObject target;
	private bool canSpawn = true;

	// Use this for initialization
	void Start () {
	
	}

	IEnumerator Spawn(){
		yield return new WaitForSeconds (Random.Range (0, 2.0f));
		GameObject go = Instantiate (bubble, this.transform.position, Quaternion.identity) as GameObject;
		go.SendMessage ("AtStart",new Pair<GameObject,float>(target,2.0f));
		canSpawn = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (canSpawn) {
			canSpawn = false;
			StartCoroutine (Spawn ());
		}
	
	}
}
