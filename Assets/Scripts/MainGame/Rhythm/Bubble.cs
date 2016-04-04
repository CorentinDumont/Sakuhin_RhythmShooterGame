using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

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
	
	}
}
