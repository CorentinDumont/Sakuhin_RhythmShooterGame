// script attached to the objects that reach the target of the rhythmgame to indicate to the player the moment he should press the "g" key
// see PlayerTitle.cs

using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

	private GameObject target; // the target object it will reach (I am thinking about adding several targets, so that each bubble can go to a different target)
	private float reachTime = 3.0f; // time in seconds to reach the target from instantiation

	void AtStart (Pair<GameObject,float> p){
		this.target = p.First;
		this.reachTime = p.Second;
	}

	// Use this for initialization
	void Start () { // calculate and set the velocity that allow the bubble to reach the target respecting the imposed time
		Vector3 distance = target.transform.position - this.transform.position;
		float floatDistance = Mathf.Sqrt (Mathf.Pow(distance.x,2)+Mathf.Pow(distance.y,2)+Mathf.Pow(distance.z,2));
		Vector3 direction = distance / floatDistance;
		this.GetComponent<Rigidbody>().velocity = direction * floatDistance / reachTime;
	}
}
