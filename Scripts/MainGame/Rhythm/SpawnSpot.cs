// Script attach to the object that will generate the bubbles for the rhythm game (see Bubble.cs, PlayerTile.cs)

using UnityEngine;
using System.Collections;

public class SpawnSpot : MonoBehaviour {

	public GameObject bubble; // prefab of the Bubbles
	public GameObject target; // the target to reach (may be changed to an array of several targets)
	private bool canSpawn = true; // can generate a bubble?

	// Use this for initialization
	void Start () {
	
	}

	IEnumerator Spawn(){ // wait randomly up to 2 seconds and generate a bubble
						// at term, this will not be random anymore, but will follow the rhythm of the music
		yield return new WaitForSeconds (Random.Range (0, 2.0f));
		GameObject go = Instantiate (bubble, this.transform.position, Quaternion.identity) as GameObject;
		go.SendMessage ("AtStart",new Pair<GameObject,float>(target,2.0f));
		canSpawn = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (canSpawn) {
			canSpawn = false;
			StartCoroutine (Spawn ()); // spawn a bubble
		}
	
	}
}
