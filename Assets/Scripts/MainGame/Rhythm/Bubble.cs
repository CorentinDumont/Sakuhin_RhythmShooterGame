<<<<<<< HEAD
﻿// script attached to the objects that reach the target of the rhythmgame to indicate to the player the moment he should press the "g" key
// see PlayerTitle.cs

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

public class Bubble : MonoBehaviour {

<<<<<<< HEAD
	private float beatTime;
	private GameObject target;

	public void Initialize (GameObject target, float reachTime){ /// called by SpawnSpot
		this.target = target;
		beatTime = Time.realtimeSinceStartup + reachTime;
		Vector3 distance = target.transform.position - this.transform.position;
		float floatDistance = Mathf.Sqrt (Mathf.Pow(distance.x,2)+Mathf.Pow(distance.y,2)+Mathf.Pow(distance.z,2));
		Vector3 direction = distance / floatDistance;
		if (reachTime > 0) {
			this.GetComponent<Rigidbody> ().velocity = direction * floatDistance / reachTime;
		}
	}

	public float GetBeatTime(){
		return beatTime;
	}

	public GameObject GetTarget(){
		return target;
=======
	private GameObject target;
	private float reachTime = 3.0f;

	void AtStart (Pair<GameObject,float> p){
		this.target = p.First;
		this.reachTime = p.Second;
	}

	// Use this for initialization
	void Start () {
		Vector3 distance = target.transform.position - this.transform.position;
		float floatDistance = Mathf.Sqrt (Mathf.Pow(distance.x,2)+Mathf.Pow(distance.y,2)+Mathf.Pow(distance.z,2));
		Vector3 direction = distance / floatDistance;
		this.GetComponent<Rigidbody>().velocity = direction * floatDistance / reachTime;
	}
	
	// Update is called once per frame
	void Update () {
	
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
	}
}
